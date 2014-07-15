/*
 * Copyright (c) 2014, Kurt Cancemi (kurt@x64architecture.com)
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

#ifdef _MSVC_
#define _CRT_SECURE_NO_WARNINGS
#endif

#include <stdio.h>

#include <openssl/pem.h>
#include <openssl/conf.h>
#include <openssl/x509v3.h>

#define KEY_PUB "conf/cert.pem"
#define KEY_PRV "conf/key.pem"

int main()
{
    EVP_PKEY *pKey;
    RSA *rsa;
    X509 *x509;
    X509_NAME *name;
    X509_EXTENSION *ex;
    FILE *fp;
    int KEY_SIZE = 2048;
    int days = 365;

    pKey = EVP_PKEY_new(); // Create a private key

    rsa = RSA_generate_key(
        KEY_SIZE, // Key length (bits)
        RSA_F4,   // Exponent
        NULL,     // Callback
        NULL      // Callback argument
        );

    EVP_PKEY_assign_RSA(pKey, rsa);

    x509 = X509_new();

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

    X509_sign(x509, pKey, EVP_sha1());

    if (!(fp = fopen(KEY_PUB, "w"))) {
        printf("Error writing to public key file");
        return -1;
    }
    if (PEM_write_X509(fp, x509) != 1)
        printf("Error while writing public key");
    fclose(fp);

    if (!(fp = fopen(KEY_PRV, "w"))) {
        printf("Error writing to private key file");
        return -1;
    }
    if (PEM_write_PrivateKey(fp, pKey, NULL, NULL, 0, NULL, NULL) != 1)
        printf("Error while writing private key");
    fclose(fp);

    X509_free(x509);
    EVP_PKEY_free(pKey);

    return 0;
}
