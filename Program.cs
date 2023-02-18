using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Enter the word to encrypt:");
        string plaintext = Console.ReadLine();

        string keyword = "hustlethegreatesthacker";
        string ciphertext = HustleEncrypt(plaintext, keyword);
        Console.WriteLine("Encrypted message: " + ciphertext);
        string decryptedText = HustleDecrypt(ciphertext, keyword);
        Console.WriteLine("Decrypted message: " + decryptedText);
    }

    static string HustleEncrypt(string plaintext, string keyword) {
        string ciphertext = "";
        int keywordIndex = 0;
        foreach (char c in plaintext) {
            int shift = (int) Char.ToUpper(keyword[keywordIndex]) - 65;
            if (Char.IsLetter(c)) {
                char shiftedChar = (char) (((int) Char.ToUpper(c) - 65 + shift) % 26 + 65);
                ciphertext += Char.IsLower(c) ? Char.ToLower(shiftedChar) : shiftedChar;
                keywordIndex = (keywordIndex + 1) % keyword.Length;
            } else if (Char.IsDigit(c)) {
                int shiftedDigit = ((int) c - 48 + shift) % 10 + 48;
                ciphertext += (char) shiftedDigit;
                keywordIndex = (keywordIndex + 1) % keyword.Length;
            } else {
                ciphertext += c;
            }
        }
        return ciphertext;
    }

    static string HustleDecrypt(string ciphertext, string keyword) {
        string plaintext = "";
        int keywordIndex = 0;
        foreach (char c in ciphertext) {
            int shift = (int) Char.ToUpper(keyword[keywordIndex]) - 65;
            if (Char.IsLetter(c)) {
                char shiftedChar = (char) (((int) Char.ToUpper(c) - 65 - shift + 26) % 26 + 65);
                plaintext += Char.IsLower(c) ? Char.ToLower(shiftedChar) : shiftedChar;
                keywordIndex = (keywordIndex + 1) % keyword.Length;
            } else if (Char.IsDigit(c)) {
                int shiftedDigit = ((int) c - 48 - shift + 10) % 10 + 48;
                plaintext += (char) shiftedDigit;
                keywordIndex = (keywordIndex + 1) % keyword.Length;
            } else {
                plaintext += c;
            }
        }
        return plaintext;
    }
}
