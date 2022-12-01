using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior _warrior;
        private string _name;
        private int _damage;
        private int _hp;
        private Warrior _enemy;

        [SetUp]
        public void Setup()
        {
            _name = "Pesho";
            _damage = 20;
            _hp = 50;
            _warrior = new Warrior(_name, _damage, _hp);
        }

        [Test]
        public void Test_WarriorConstructor_ShouldWork()
        {
            Assert.AreEqual(_name, _warrior.Name);
            Assert.AreEqual(_damage, _warrior.Damage);
            Assert.AreEqual(_hp, _warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("                    ")]
        public void Test_NameProperty_ShouldThrow(string name)
        {
            Assert.Throws<ArgumentException>(() => { _warrior = new Warrior(name, _damage, _hp); },
                "Name should not be empty or whitespace!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void Test_DamageProperty_ShouldThrow(int damage)
        {
            Assert.Throws<ArgumentException>(() => { _warrior = new Warrior(_name, damage, _hp); },
                "Damage value should be positive!");
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void Test_HpProperty_ShouldThrow(int hp)
        {
            Assert.Throws<ArgumentException>(() => { _warrior = new Warrior(_name, _damage, hp); },
                "Your HP is too low in order to attack other warriors!");
        }

        //Constructor is tested and Works! Hence can call values for second Warrior!
        [Test]
        public void Test_AttackMethodReducesHpOfWarriorByDamageValue_ShouldWork()
        {
            _enemy = new Warrior("Gosho", 10, 40);

            _warrior.Attack(_enemy);

            int expectedHealth = _hp - _enemy.Damage;
            int actualHealth = _warrior.HP;

            Assert.AreEqual(expectedHealth, actualHealth);
        }

        [Test]
        public void Test_AttackMethodReducesHpOfEnemyByDamageValue_ShouldWork()
        {
            _enemy = new Warrior("Gosho", 10, 40);

            int expectedHealth = _enemy.HP - _damage;

            _warrior.Attack(_enemy);
            int actualHealth = _enemy.HP;

            Assert.AreEqual(expectedHealth, actualHealth);
        }

        [Test]
        public void Test_AttackMethodReducesHpOfEnemyByDamageValue_KillsEnemy()
        {
            _warrior = new Warrior("Pesho", 41, 35);
            _enemy = new Warrior("Gosho", 10, 40);

            int expectedHealth = 0;

            _warrior.Attack(_enemy);
            int actualHealth = _enemy.HP;

            Assert.AreEqual(expectedHealth, actualHealth);
        }

        [Test]
        public void Test_AttackMethodWarriorCannotAttack_ShouldThrow()
        {
            _warrior = new Warrior(_name, _damage, 30);
            _enemy = new Warrior("Gosho", 10, 40);

            Assert.Throws<InvalidOperationException>(() => { _warrior.Attack(_enemy); },
                "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void Test_AttackMethodEnemyCannotAttack_ShouldThrow()
        {
            _warrior = new Warrior(_name, _damage, 35);
            _enemy = new Warrior("Gosho", 10, 30);

            Assert.Throws<InvalidOperationException>(() => { _warrior.Attack(_enemy); },
                "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void Test_AttackMethodWarriorCannotAttackTooWeak_ShouldThrow()
        {
            _warrior = new Warrior(_name, _damage, _hp);
            _enemy = new Warrior("Gosho", 60, 40);

            Assert.Throws<InvalidOperationException>(() => { _warrior.Attack(_enemy); },
                "You are trying to attack too strong enemy");
        }
    }
}