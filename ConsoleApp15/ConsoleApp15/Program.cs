/*
 * На вход программе подается строка (длиной не более 200 символов),
 * в которой нужно зашифро-вать все английские слова 
 * (словом называется непрерывная последовательность английских букв, слова друга от друга отделяются любыми другими символами, длина слова не превышает 20 символов).
 * Строка заканчивается символом #, других символов # в строке нет. Каждое слово зашифровано с помощью циклического сдвига на длину этого слова. Например, если длина сло-ва равна K, каждая буква в слове заменяется на букву, стоящую в английском алфавите на K букв дальше (алфавит считается циклическим, то есть, за буквой Z стоит буква A). Строчные буквы при этом остаются строчными, а прописные – прописными. Символы, не являющиеся английскими буквами, не изменяются.
Требуется написать программу, которая будет выводить
на экран текст зашифрованного сооб-щения. Например, если исходный текст был таким:
Day, mice. "Year" is a mistake# 
то результат шифровки должен быть следующий:
Gdb, qmgi. "Ciev" ku b tpzahrl#
*/

char cipher(char ch, int key)
{
    if (!char.IsLetter(ch))
    {

        return ch;
    }

    char d = char.IsUpper(ch) ? 'A' : 'a';
    return (char)((((ch + key) - d) % 26) + d);


}

string Encipher(string input, int key)
{
    string output = string.Empty;

    foreach (char ch in input)
        output += cipher(ch, key);

    return output;
}

string Decipher(string input, int key)
{
    return Encipher(input, 26 - key);
}

Console.WriteLine("Type a string to encrypt:");
string UserString = Console.ReadLine();


int get_lenght(string word)
{
    int count = 0;
    for (int i = 0; i < word.Length; i++)
    {
        if (char.IsLetter(word[i])) { count++; }
    }
    return count;
}

List<string> w = new List<string>();

var words = UserString.Split(' ', StringSplitOptions.TrimEntries);

for (int i = 0; i < words.Length; i++)
{
    w.Add(Encipher(words[i], get_lenght(words[i])));
}

Console.WriteLine(String.Join(' ', w));
