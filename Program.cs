namespace FluentBuilderInheritanceWithRecursiveGenerics;

public class Person
{
    public string Name;
    public string Position;
    public string Hobbie;

    public class Builder : PersonHobbieBuilder<Builder>
    {

    }

    public static Builder New => new Builder();

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}, {nameof(Hobbie)}: {Hobbie}";
    }
}

public abstract class PersonBuilder
{
    protected Person person = new Person();
    public Person Build()
    {
        return person;
    }
}

public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
{
    public SELF Called(string name)
    {
        person.Name = name;
        return (SELF)this;
    }
}

public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF : PersonJobBuilder<SELF>
{
    public SELF WorksAsA(string position)
    {
        person.Position = position;
        return (SELF)this;
    }
}

public class PersonHobbieBuilder<SELF> : PersonJobBuilder<PersonHobbieBuilder<SELF>> where SELF : PersonHobbieBuilder<SELF>
{
    public SELF HaveFunWith(string hobbie)
    {
        person.Hobbie = hobbie;
        return (SELF)this;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var me = Person.New.Called("Dmitri").WorksAsA("Quant").HaveFunWith("Video games").Build();
        System.Console.WriteLine(me);
    }
}
