using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());

            HeroCollection heroCollection = new HeroCollection();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] heroInputStrings = Console.ReadLine().Split(" ").ToArray();

                Hero hero = new Hero(heroInputStrings[0],
                    int.Parse(heroInputStrings[1]), int.Parse(heroInputStrings[2]));

                heroCollection.Heroes.Add(hero);
            }

            while (true)
            {
                string[] commandStrings = Console.ReadLine().Split(" - ").ToArray();

                if (commandStrings[0] == "End")
                {
                    break;
                }

                string commandName = commandStrings[0];

                switch (commandName)
                {
                    case "CastSpell":
                        string heroName = commandStrings[1];
                        int mpNeeded = int.Parse(commandStrings[2]);
                        string spellName = commandStrings[3];

                        int indexOfHero = heroCollection.Heroes.FindIndex(h => h.HeroName == heroName);

                        heroCollection.Heroes[indexOfHero].CastSpell(mpNeeded, spellName);

                        break;
                    case "TakeDamage":
                        heroName = commandStrings[1];
                        int damage = int.Parse(commandStrings[2]);
                        string attacker = commandStrings[3];

                        indexOfHero = heroCollection.Heroes.FindIndex(h => h.HeroName == heroName);

                        heroCollection.Heroes[indexOfHero].TakeDamage(damage, attacker);

                        bool deadHero = heroCollection.Heroes[indexOfHero].IsDead();

                        if (deadHero)
                        {
                            heroCollection.Heroes.RemoveAt(indexOfHero);
                            //heroCollection.Heroes.Remove(heroCollection.Heroes[indexOfHero]);
                        }

                        break;
                    case "Recharge":
                        heroName = commandStrings[1];
                        int recharge = int.Parse(commandStrings[2]);

                        indexOfHero = heroCollection.Heroes.FindIndex(h => h.HeroName == heroName);

                        heroCollection.Heroes[indexOfHero].Recharge(recharge);

                        break;
                    case "Heal":
                        heroName = commandStrings[1];
                        int heal = int.Parse(commandStrings[2]);

                        indexOfHero = heroCollection.Heroes.FindIndex(h => h.HeroName == heroName);

                        heroCollection.Heroes[indexOfHero].Heal(heal);

                        break;
                }
            }

            foreach (Hero hero in heroCollection.Heroes)
            {
                Console.WriteLine($"{hero.HeroName}");
                Console.WriteLine($"  HP: {hero.HP}");
                Console.WriteLine($"  MP: {hero.MP}");
            }
        }
    }

    class Hero
    {
        public Hero(string heroName, int hp, int mp)
        {
            this.HeroName = heroName;
            this.HP = hp;
            this.MP = mp;
        }

        public string HeroName { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

        public void CastSpell(int mpNeeded, string spellName)
        {
            if (mpNeeded > this.MP)
            {
                Console.WriteLine($"{this.HeroName} does not have enough MP to cast {spellName}!");
            }
            else
            {
                this.MP -= mpNeeded;

                Console.WriteLine($"{this.HeroName} has successfully cast {spellName} and now has {this.MP} MP!");
            }
        }

        public void TakeDamage(int damage, string attacker)
        {
            this.HP -= damage;

            if (this.HP > 0)
            {
                Console.WriteLine($"{this.HeroName} was hit for {damage} HP by {attacker} and now has {this.HP} HP left!");
            }
            else
            {
                Console.WriteLine($"{this.HeroName} has been killed by {attacker}!");
            }
        }
        public bool IsDead()
        {
            bool isDead = false;

            if (this.HP <= 0)
            {
                isDead = true;
            }

            return isDead;
        }

        public void Recharge(int amount)
        {
            int recharged = this.MP + amount;

            if (recharged > 200)
            {
                amount = 200 - this.MP;

                this.MP = 200;
            }
            else
            {
                this.MP = recharged;
            }

            Console.WriteLine($"{this.HeroName} recharged for {amount} MP!");
        }

        public void Heal(int amount)
        {
            int healedAmount = this.HP + amount;

            if (healedAmount > 100)
            {
                amount = 100 - this.HP;

                this.HP = 100;
            }
            else
            {
                this.HP = healedAmount;
            }

            Console.WriteLine($"{this.HeroName} healed for {amount} HP!");
        }
    }

    class HeroCollection
    {
        public HeroCollection()
        {
            Heroes = new List<Hero>();
        }

        public List<Hero> Heroes { get; set; }


    }
}
