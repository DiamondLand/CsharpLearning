using System;

public interface ICommand
{
    void Execute();
}

public class SaveCommand : ICommand
{
    private readonly Document _document;

    public SaveCommand(Document document)
    {
        _document = document;
    }

    public void Execute()
    {
        _document.Save();
    }
}

public class Button
{
    private ICommand _command;

    public Button(ICommand command)
    {
        _command = command;
    }

    public void Click()
    {
        _command.Execute();
    }
}

public class Document
{
    public void Save()
    {
        Console.WriteLine("Сохранено");
    }
}

public class HotkeySave
{
    private readonly ICommand _command;

    public HotkeySave(ICommand command)
    {
        _command = command;
    }

    public void Press()
    {
        _command.Execute();
    }
}

class Program
{
    static void Main()
    {
        Document document = new Document();
        ICommand saveCommand = new SaveCommand(document);

        Button saveButton = new Button(saveCommand);
        saveButton.Click(); // Сохранение через кнопку

        HotkeySave hotkeySave = new HotkeySave(saveCommand);
        hotkeySave.Press(); // Сохранение через горячие клавиши

        Console.ReadLine();
    }
}
