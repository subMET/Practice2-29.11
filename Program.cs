// 1. RequestNumber()
// 2. MakeMove()
// 3. GameCicle()
// 4. GameInitialization()

int[] GameInitialization(int attempt, int secret)
{
    int right = 0;
    int[] answers = { 0, 0 };
    System.Console.WriteLine("Секретное число будет загадано между 1 и введённым положительным числом. Введите правую границу.");
    right = Convert.ToInt32(Console.ReadLine());
    right = Math.Abs(right);
    secret = new Random().Next(1, right + 1);
    for (int i = right; i > 0;)
    {
        attempt = attempt + 1;
        i = i / 2;
    }
    System.Console.WriteLine("Введите уровень сложности: 0 - легко, 1 - средне, 2 - сложно.");
    int difficulty = Convert.ToInt32(Console.ReadLine());
    int check = attempt;
    if (difficulty == 0)
    {
        attempt = attempt + attempt / 4;
        if (attempt == check) attempt = attempt + 1;
    }
    if (difficulty == 2)
    {
        attempt = attempt - attempt / 4;
        if (attempt == check && attempt != 1) attempt = attempt - 1;
    }
    System.Console.WriteLine($"У вас есть {attempt} попыток.");
    answers[0] = attempt;
    answers[1] = secret;
    return answers;
}

int RequestNumber()
{
    System.Console.WriteLine("Угадайте загаданное компьютером число. Введите ваше предположение.");
    int currentNumber = Convert.ToInt32(Console.ReadLine());
    return currentNumber;
}

bool MakeMove(int secret1)
{
    int N = RequestNumber();
    if (N == secret1)
    {
        System.Console.WriteLine($"Вы угадали! Это число {secret1}.");
        return true;
    }
    if (N > secret1)
    {
        System.Console.WriteLine($"Загаданное число меньше {N}.");
    }
    else
    {
        System.Console.WriteLine($"Загаданное число больше {N}.");
    }
    return false;
}

void GameCicle(int attem, int secr)
{
    bool result = false;
    while (attem > 0 && result == false)
    {
        result = MakeMove(secr);
        attem = attem - 1;
    }
    if (attem == 0)
    {
        System.Console.WriteLine("Вы проиграли, игра окончена.");
    }
    else
    {
        System.Console.WriteLine($"Вы выиграли. У вас оставалось ещё {attem} попыток.");
    }
}

int att = 0;
int secretNumber = 0;
int[] AttAndSec = GameInitialization(att, secretNumber);
att = AttAndSec[0];
secretNumber = AttAndSec[1];
GameCicle(att, secretNumber);