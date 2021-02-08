using System;

namespace Proiecty_MLSA.Classes
{
    public interface IInformationBuilder
    {
        IInformationBuilder setAge(int age);
        IInformationBuilder setName(String Name);
        IInformationBuilder setAverageRating(double AverageRating);
        Information Build();
    }
}
