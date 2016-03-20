/*
 * Copyright (c) 2014 - 2016, Kurt Cancemi (kurt@x64architecture.com)
 *
 * Permission to use, copy, modify, and/or distribute this software for any
 * purpose with or without fee is hereby granted, provided that the above
 * copyright notice and this permission notice appear in all copies.
 *
 * THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
 * WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
 * MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
 * ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
 * WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
 * ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
 * OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
 */

#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif

#include <stdio.h>

#include <openssl/pem.h>
#include <openssl/conf.h>
#include <openssl/x509v3.h>

#define KEY_PUB "conf/cert.pem"
#define KEY_PRV "conf/key.pem"

int generate_keypair(int bits, int days)
{
	BIGNUM *bnexp = NULL;
	EVP_PKEY *pKey = NULL;
	RSA *rsa = NULL;
	X509 *x509 = NULL;
	X509_NAME *name;
	X509_EXTENSION *ex;
	FILE *fp = NULL;
	int rv;
	unsigned long exp = RSA_F4;

	if ((pKey = EVP_PKEY_new()) == NULL) {
		printf("Error allocating EVP_PKEY struct\n");
		goto err;
	}

	if ((rsa = RSA_new()) == NULL) {
		printf("Error allocating RSA struct\n");
		goto err;
	}
	if ((bnexp = BN_new()) == NULL) {
		printf("Error allocating bignum struct\n");
		goto err;
	}
	if (BN_set_word(bnexp, exp) != 1) {
		printf("Error setting exponent\n");
		goto err;
	}


	rv = RSA_generate_key_ex(rsa, bits, bnexp, NULL);
	if (rv != 1) {
		printf("Error generating RSA key\n");
		goto err;
	}

	EVP_PKEY_assign_RSA(pKey, rsa);

	if ((x509 = X509_new()) == NULL) {
		printf("Error allocating X509 struct\n");
		goto err;
	}

	X509_set_version(x509, 3);
	ASN1_INTEGER_set(X509_get_serialNumber(x509), 1);
	X509_gmtime_adj(X509_get_notBefore(x509), 0);
	X509_gmtime_adj(X509_get_notAfter(x509), (long)60 * 60 * 24 * days);
	X509_set_pubkey(x509, pKey);

	name = X509_get_subject_name(x509);

	X509_NAME_add_entry_by_txt(name, "C",
		MBSTRING_ASC, "Wnmp", -1, -1, 0);
	X509_NAME_add_entry_by_txt(name, "CN",
		MBSTRING_ASC, "Wnmp", -1, -1, 0);

	X509_set_issuer_name(x509, name);

	ex = X509V3_EXT_conf_nid(NULL, NULL, NID_netscape_cert_type, "server");
	X509_add_ext(x509, ex, -1);
	X509_EXTENSION_free(ex);

	ex = X509V3_EXT_conf_nid(NULL, NULL, NID_netscape_comment,
		"Wnmp by Kurt Cancemi");
	X509_add_ext(x509, ex, -1);
	X509_EXTENSION_free(ex);

	ex = X509V3_EXT_conf_nid(NULL, NULL, NID_netscape_ssl_server_name,
		"localhost");

	X509_add_ext(x509, ex, -1);
	X509_EXTENSION_free(ex);

	X509_sign(x509, pKey, EVP_sha256());

	if (!(fp = fopen(KEY_PUB, "w"))) {
		printf("Error writing to public key file");
		goto err;
	}
	if (PEM_write_X509(fp, x509) != 1) {
		printf("Error while writing public key");
		goto err;
	}
	fclose(fp);

	if (!(fp = fopen(KEY_PRV, "w"))) {
		printf("Error writing to private key file");
		goto err;
	}
	if (PEM_write_PrivateKey(fp, pKey, NULL, NULL, 0, NULL, NULL) != 1) {
		printf("Error while writing private key");
	}
	fclose(fp);

	BN_free(bnexp);
	X509_free(x509);
	EVP_PKEY_free(pKey);

	return 0;

err:
	BN_free(bnexp);
	X509_free(x509);
	EVP_PKEY_free(pKey);

	return -1;
}

int main(void)
{
	int rv;
	rv = generate_keypair(2048, 365);

	return rv;
}