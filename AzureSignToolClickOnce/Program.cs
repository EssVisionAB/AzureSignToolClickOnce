﻿using AzureSignToolClickOnce.Services;
using System;

namespace AzureSignToolClickOnce
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = ".";
            var description = string.Empty;
            string timeStampUrl = string.Empty;
            string timeStampUrlRfc3161 = string.Empty;
            var keyVaultUrl = string.Empty;
            var ADTenantId = string.Empty;
            var clientId = string.Empty;
            var clientSecret = string.Empty;
            var certName = string.Empty;

            foreach (string arg in args)
            {
                if (!arg.StartsWith("-") || arg.Length < 4)
                    continue;

                var split = arg.IndexOf('=');
                if (split == -1)
                    continue;

                var key = arg.Substring(0, split).Trim();
                var value = arg.Substring(split + 1, arg.Length - split - 1).Trim();

                switch (key)
                {
                    case "-p":
                    case "-path":
                        path = value;
                        break;
                    case "-azure-key-vault-url":
                    case "-kvu":
                        keyVaultUrl = value;
                        break;
                    case "-azure-key-vault-client-id":
                    case "-kvi":
                        clientId = value;
                        break;
                    case "-azure-key-vault-client-secret":
                    case "-kvs":
                        clientSecret = value;
                        break;
                    case "-azure-key-vault-tenant-id":
                    case "-kvt":
                        ADTenantId = value;
                        break;
                    case "-azure-key-vault-certificate":
                    case "-kvc":
                        certName = value;
                        break;
                    case "-timestamp-sha2":
                    case "-td":
                        timeStampUrl = value;
                        break;
                    case "-timestamp-rfc3161":
                    case "-tr":
                        timeStampUrlRfc3161 = value;
                        break;
                    case "-description":
                    case "-d":
                        description = value;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Path: {path}");

            if (string.IsNullOrEmpty(keyVaultUrl))
            {
                Console.WriteLine($"Missing option -kvu | -azure-key-vault-url");
                return;
            }
            if (string.IsNullOrEmpty(clientId))
            {
                Console.WriteLine($"Missing option -kvi | -azure-key-vault-client-id");
                return;
            }
            if (string.IsNullOrEmpty(clientSecret))
            {
                Console.WriteLine($"Missing option -kvs | -azure-key-vault-client-secret");
                return;
            }
            if (string.IsNullOrEmpty(ADTenantId))
            {
                Console.WriteLine($"Missing option -kvt | -azure-key-vault-tenant-id");
                return;
            }
            if (string.IsNullOrEmpty(certName))
            {
                Console.WriteLine($"Missing option -kvc | -azure-key-vault-certificate");
                return;
            }
            if (string.IsNullOrEmpty(description))
            {
                Console.WriteLine($"Missing option -d | -description");
                return;
            }
            if (string.IsNullOrEmpty(timeStampUrl))
            {
                Console.WriteLine($"Missing option -tr | -timestamp-sha2");
            }
            if (string.IsNullOrEmpty(timeStampUrlRfc3161))
            {
                Console.WriteLine($"Missing option -td | -timestamp-rfc3161");
            }

            var service = new AzureSignToolService();
            service.Start(description, path, timeStampUrl, timeStampUrlRfc3161, keyVaultUrl, ADTenantId, clientId, clientSecret, certName);
        }
    }
}
