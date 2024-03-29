﻿using desafio_back_end_picpay.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace desafio_back_end_picpay.Utils;

 public static class UtilsClass
{
    public static string RemoveSpecialCharacters(string input)
    {
        return Regex.Replace(input, "[^0-9]", "");
    }

    public static bool DetectSpecialCharacters(string input)
    {
        string pattern = @"[^A-Za-z0-9]|[\.\-/]";

        return Regex.IsMatch(input, pattern);
    }

    public static string FormatCPF(string input)
    {
        if (!input.IsNullOrEmpty())
        {

            if (input.Length < 11 || input.Length >= 14)
            {
                throw new WrongDocumentNumberException("Invalid CPF format");
            }

            return $"{input.Substring(0, 3)}.{input.Substring(3, 3)}.{input.Substring(6, 3)}-{input.Substring(9)}";
        }
        throw new WrongDocumentNumberException("Error when formatting CPF. CPF is null or empty");
    }

    public static string FormatCNPJ(string input)
    {
        if (input.Length != 14 || !IsNumeric(input))
        {
            throw new WrongDocumentNumberException("Invalid CNPJ format");
        }

        return $"{input.Substring(0, 2)}.{input.Substring(2, 3)}.{input.Substring(5, 3)}/{input.Substring(8, 4)}-{input.Substring(12)}";
    }

    static bool IsNumeric(string input)
    {
        return long.TryParse(input, out _);
    }

}
