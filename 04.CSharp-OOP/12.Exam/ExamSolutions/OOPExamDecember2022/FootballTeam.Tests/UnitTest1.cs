using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private string _name;
        private int _playerNumber;
        private string _position;
        private int _scoredGoals;
        private FootballPlayer _footballPlayer;
        private string _teamName;
        private int _teamCapacity;
        private List<FootballPlayer> _players;
        private FootballTeam _team;

        [SetUp]
        public void Setup()
        {
            _name = "Park";
            _playerNumber = 13;
            _position = "Midfielder";
            _scoredGoals = 0;
            _footballPlayer = new FootballPlayer(_name, _playerNumber, _position);

            _players = new List<FootballPlayer>();
            _teamName = "United";
            _teamCapacity = 16;
            _team = new FootballTeam(_teamName, _teamCapacity);
        }

        [Test]
        public void Test_Constructor_FootballPlayer_ShouldWork()
        {
            Assert.AreEqual(_name, _footballPlayer.Name);
            Assert.AreEqual(_playerNumber, _footballPlayer.PlayerNumber);
            Assert.AreEqual(_position, _footballPlayer.Position);
            Assert.AreEqual(_scoredGoals, _footballPlayer.ScoredGoals);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_Property_PlayerName_ShouldThrow(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _footballPlayer = new FootballPlayer(name, _playerNumber, _position);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(22)]
        [TestCase(-1)]
        public void Test_Property_PlayerNumber_ShouldThrow(int playerNumber)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _footballPlayer = new FootballPlayer(_name, playerNumber, _position);
            });
        }

        [Test]
        [TestCase("CM")]
        [TestCase("Goal")]
        public void Test_Property_PlayerPosition_ShouldThrow(string position)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _footballPlayer = new FootballPlayer(_name, _playerNumber, position);
            });
        }

        [Test]
        public void Test_Method_Score_IncreasesScoredGoals()
        {
            _footballPlayer.Score();
        
            Assert.AreEqual(_scoredGoals + 1, _footballPlayer.ScoredGoals);
        }

        [Test]
        public void Test_Property_ScoredGoals_ReturnsGoals()
        {
            _footballPlayer.Score();

            int expectedGoals = _scoredGoals + 1;
            int actualGoals = _footballPlayer.ScoredGoals;

            Assert.That(actualGoals, Is.EqualTo(expectedGoals));
        }

        [Test]
        public void Test_Constructor_FootballTeam_ShouldWork()
        {
            Assert.AreEqual(_teamName, _team.Name);
            Assert.AreEqual(_teamCapacity, _team.Capacity);
            CollectionAssert.AreEqual(_players, _team.Players);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_Property_TeamName_ShouldThrow(string teamName)
        {
            Assert.Throws<ArgumentException>(() => { _team = new FootballTeam(teamName, _teamCapacity); });
        }

        [Test]
        [TestCase(0)]
        [TestCase(14)]
        public void Test_Property_TeamCapacity_ShouldThrow(int capacity)
        {
            Assert.Throws<ArgumentException>(() => { _team = new FootballTeam(_teamName, capacity); });
        }

        [Test]
        public void Test_Method_AddNewPlayer_ShouldWork()
        {
            _team.AddNewPlayer(_footballPlayer);


            Assert.That(_team.AddNewPlayer(_footballPlayer),
                Is.EqualTo(
                    $"Added player {_footballPlayer.Name} in position {_footballPlayer.Position} with number {_footballPlayer.PlayerNumber}"));
        }

        [Test]
        public void Test_Method_AddNewPlayer_ShouldThrow()
        {
            for (int i = 0; i < _teamCapacity; i++)
            {
                _team.AddNewPlayer(_footballPlayer);
            }

            Assert.That(_team.AddNewPlayer(_footballPlayer), Is.EqualTo("No more positions available!"));
        }

        [Test]
        public void Test_Method_PlayerScore_ShouldWork()
        {
            _team.AddNewPlayer(_footballPlayer);
            _team.PlayerScore(_playerNumber);

            Assert.That(_team.PlayerScore(_playerNumber),
                Is.EqualTo(
                    $"{_footballPlayer.Name} scored and now has {_footballPlayer.ScoredGoals} for this season!"));

            Assert.AreEqual(2, _footballPlayer.ScoredGoals);
        }

        [Test]
        public void Test_Method_PickPLayer_ShouldWork()
        {
            FootballPlayer expectedPlayer = _footballPlayer;
            _team.AddNewPlayer(_footballPlayer);
            _team.AddNewPlayer(_footballPlayer);

            Assert.That(_team.PickPlayer(_footballPlayer.Name), Is.EqualTo(expectedPlayer));
        }

        [Test]
        public void Test_Property_Players_ReturnsPlayers()
        {
            _team.AddNewPlayer(_footballPlayer);
            _players.Add(_footballPlayer);

            CollectionAssert.AreEqual(_players, _team.Players);
        }
    }
}