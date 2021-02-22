using System;

namespace Proiecty_MLSA.Classes
{
    public interface IInformationBuilder
    {
        IInformationBuilder SetAge(int age);
        IInformationBuilder SetName(String Name);
        IInformationBuilder SetAverageRating(double AverageRating);
        Information Build();
    }
}
