using HumansCreator.Enumerations;

namespace HumansCreator.Models
{
    public class Creator
    {
        public static Human CreateNewHuman(int age)
        {
            Human human = new Human();
            human.Age = age;

            if (age % 2 == 0)
            {
                human.Name = "Batkata";
                human.Gender = Gender.UltraBro;
            }
            else
            {
                human.Name = "Maceto";
                human.Gender = Gender.NiceChick;
            }

            return human;
        }
    }
}
