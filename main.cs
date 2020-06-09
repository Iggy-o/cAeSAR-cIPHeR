/*
Ighoise Odigie
June 7, 2020
Youtube: https://www.youtube.com/channel/UCud4cJjtCjEwKpynPz-nNaQ?
Github: https://github.com/Iggy-o
Preview: https://repl.it/@IghoiseO/cAeSAR-cIPHeR
Here is some info on Caesar Cipher's: https://en.wikipedia.org/wiki/Caesar_cipher
*/
using System;

namespace encryption
{
  class MainClass {
    public static void decryptPassword(string letters, string specialCharacters, string passwd, int key){
      char[] shiftedAlphabet = letters.ToCharArray();
      char[] shiftedCharacters = specialCharacters.ToCharArray();
      for (int a = 0; a < key; a++) {
        //The last letter is saved
        char lastLetter = shiftedAlphabet[shiftedAlphabet.Length - 1];
        char lastCharacter = shiftedCharacters[shiftedCharacters.Length - 1];
        for (int b = shiftedAlphabet.Length - 1; b > 0; b--) {
          //Every letter up to the last letter is swapped to the 
          shiftedAlphabet[b] = shiftedAlphabet[b - 1];
          shiftedCharacters[b] = shiftedCharacters[b - 1];
        }
        shiftedAlphabet[0] = lastLetter;
        shiftedCharacters[0] = lastCharacter;
      }
      string shiftedString = string.Join("", shiftedAlphabet);
      string characterString = string.Join("", shiftedCharacters);
      char[] passwdArr = passwd.ToCharArray();
      char[] finalPasswdArr = new char[passwd.Length];
      int placement;
      char newLetter;
      bool invalid = false;
      for (int i = 0; i < passwd.Length; i++) {
        char passwdLetter = passwdArr[i];
        char upperPasswd = char.ToUpper(passwdLetter);
        if (char.Equals(upperPasswd, ' ')) {
          newLetter = upperPasswd;
        }
        else if(char.IsLetter(upperPasswd)){
          placement = shiftedString.IndexOf(upperPasswd);
          newLetter = letters[placement];
          if (char.IsLower(passwdLetter)) {
            newLetter = char.ToLower(newLetter);
          }
        }
        else{
          placement = characterString.IndexOf(upperPasswd);
          if (placement == -1) {
            invalid = true;
            break;
          }
          else {
            newLetter = specialCharacters[placement];
          }
        }
        finalPasswdArr[i] = newLetter;
      }
      if (invalid == false) {
        string decryptedPasswd = string.Join("", finalPasswdArr);
        Console.WriteLine("\nDecrypted Password: {0}", decryptedPasswd);
      }
      else{
        Console.WriteLine("\nINVALID ENTRY\n(PLEASE TRY AGAIN)");
      }
    }

    public static void encryptPassword(string letters, string specialCharacters){
       //The following shifts the each letter in the alpheet by the amount (encryptionKey)
      float encryptionKey = new Random().Next(1, letters.Length-1);
      char[] shiftedAlphabet = letters.ToCharArray();
      char[] shiftedCharacters = specialCharacters.ToCharArray();
      for (int a = 0; a < encryptionKey; a++) {
        //The last letter is saved
        char lastLetter = shiftedAlphabet[shiftedAlphabet.Length - 1];
        char lastCharacter = shiftedCharacters[shiftedCharacters.Length - 1];
        for (int b = shiftedAlphabet.Length - 1; b > 0; b--) {
          //Every letter up to the last letter is swapped to the 
          shiftedAlphabet[b] = shiftedAlphabet[b - 1];
          shiftedCharacters[b] = shiftedCharacters[b - 1];
        }
        shiftedAlphabet[0] = lastLetter;
        shiftedCharacters[0] = lastCharacter;
      }
      Console.WriteLine("\nChoose a valid password: ");
      string passwd = Console.ReadLine();
      char[] passwdArr = passwd.ToCharArray();
      char[] finalPasswdArr = new char[passwd.Length];
      int placement;
      char newLetter;
      bool invalid = false;
      for (int i = 0; i < passwd.Length; i++) {
        char passwdLetter = passwdArr[i];
        char upperPasswd = char.ToUpper(passwdLetter);
        if (char.Equals(upperPasswd, ' ')) {
          newLetter = upperPasswd;
        }
        else if (char.IsLetter(upperPasswd)) {
          placement = letters.IndexOf(upperPasswd);
          newLetter = shiftedAlphabet[placement];
          if (char.IsLower(passwdLetter)) {
            newLetter = char.ToLower(newLetter);
          }
        }
        else{
          placement = specialCharacters.IndexOf(upperPasswd);
          if (placement == -1) {
            invalid = true;
            break;
          }
          else {
            newLetter = shiftedCharacters[placement];
          }
        }
        finalPasswdArr[i] = newLetter;
      }
      if (invalid == false) {
        string encryptedPasswd = string.Join("", finalPasswdArr);
        Console.WriteLine("\nEncrypted Password: {0}\n(Your decryption key: {1})\n\n\n[Note: Copy the encrypted password along with the key and try decrypting]", encryptedPasswd, encryptionKey);
      }
      else{
        Console.WriteLine("\nINVALID ENTRY\n(PLEASE TRY AGAIN)");
      }
    }
    
    public static void Main (string[] args) {
      //This is the title
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Ywaown+Yeldan: Encryption Service\n(Key = 4)");
      Console.ResetColor();

      //In the following variable I initialize all valid characters for the user password
      string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      string specialCharacters = "1234567890!@#$%^&*-_.+|:?~";
      
      //First the user is asked what they want to do
      Console.WriteLine("\nDo you have a previous encrypted password to decrypt (Y or N): ");
      string isDecrypt = Console.ReadLine();
      isDecrypt = isDecrypt.ToUpper();
      if (string.Equals(isDecrypt, "Y")) {
        Console.WriteLine("\nWhat is your key: ");
        string userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int key)){
          Console.WriteLine("\nWhat was the encrypted password: ");
          string passwd = Console.ReadLine();
          decryptPassword(letters, specialCharacters, passwd, key);
        }
        else{
          Console.WriteLine("\nINVALID ENTRY\n(PLEASE TRY AGAIN)");
        }
      }
      else if (string.Equals(isDecrypt, "N")){
        encryptPassword(letters, specialCharacters);
      }
      else {
        Console.WriteLine("\nINVALID ENTRY\n(PLEASE TRY AGAIN)");
      }
    }
  }
}