using NUnit.Framework;
using System;
using BattleStrategy;
using BattleStrategy.Warriors;
using BattleStrategy.Battles;

namespace BattleStrategy.UnitTests
{

    [TestFixture]
    public class ArmyUnitTests
    {
        ArmyUnitTrainer trainer;
        WarriorBuilder warriorBuilder;
        KnightBuilder knightBuilder;
        DefenderBuilder defenderBuilder;
        VampireBuilder vampireBuilder;
        LancerBuilder lancerBuilder;
        HealerBuilder healerBuilder;

        [SetUp]
        public void Setup()
        {
            trainer = new ArmyUnitTrainer();
            warriorBuilder = new WarriorBuilder();
            knightBuilder = new KnightBuilder();
            defenderBuilder = new DefenderBuilder();
            vampireBuilder = new VampireBuilder();
            lancerBuilder = new LancerBuilder();
            healerBuilder = new HealerBuilder();
        }

        [Test]
        public void CreatingWarrior_WithBuilder_ReturnsTrue()
        {
            //Arrange
            Warrior warrior;

            //Act
            warrior = trainer.Create(warriorBuilder);

            //Assert
            Assert.IsNotNull(warrior);
            Assert.AreEqual(WarriorType.Warrior, warrior.Type);
            Assert.IsTrue(warrior.IsAlive);
        }

        [Test]
        public void CreatingKnight_WithBuilder_ReturnsTrue()
        {
            //Arrange
            Warrior knight;

            //Act
            knight = trainer.Create(knightBuilder);

            //Assert
            Assert.IsNotNull(knight);
            Assert.AreEqual(WarriorType.Knight, knight.Type);
            Assert.IsTrue(knight.IsAlive);
        }

        [Test]
        public void CreatingDefender_WithBuilder_ReturnsTrue()
        {
            //Arrange
            Warrior defender;

            //Act
            defender = trainer.Create(defenderBuilder);

            //Assert
            Assert.IsNotNull(defender);
            Assert.AreEqual(WarriorType.Defender, defender.Type);
            Assert.IsTrue(defender.IsAlive);
        }

        [Test]
        public void CreatingVampire_WithBuilder_ReturnsTrue()
        {
            //Arrange
            Warrior vampire;

            //Act
            vampire = trainer.Create(vampireBuilder);

            //Assert
            Assert.IsNotNull(vampire);
            Assert.AreEqual(WarriorType.Vampire, vampire.Type);
            Assert.IsTrue(vampire.IsAlive);
        }

        [Test]
        public void CreatingLancer_WithBuilder_ReturnsTrue()
        {
            //Arrange
            Warrior lancer;

            //Act
            lancer = trainer.Create(lancerBuilder);

            //Assert
            Assert.IsNotNull(lancer);
            Assert.AreEqual(WarriorType.Lancer, lancer.Type);
            Assert.IsTrue(lancer.IsAlive);
        }

        [Test]
        public void CreatingHealer_WithBuilder_ReturnsTrue()
        {
            //Arrange
            Warrior healer;

            //Act
            healer = trainer.Create(healerBuilder);

            //Assert
            Assert.IsNotNull(healer);
            Assert.AreEqual(WarriorType.Healer, healer.Type);
            Assert.IsTrue(healer.IsAlive);
        }
    }

    [TestFixture]
    class RankTests
    {
        ArmyUnitTrainer trainer;
        WarriorBuilder warriorBuilder;
        KnightBuilder knightBuilder;
        DefenderBuilder defenderBuilder;
        VampireBuilder vampireBuilder;
        LancerBuilder lancerBuilder;
        HealerBuilder healerBuilder;
        Warrior[] assortedWarriors;

        [SetUp]
        public void SetUp()
        {
            trainer = new ArmyUnitTrainer();
            warriorBuilder = new WarriorBuilder();
            knightBuilder = new KnightBuilder();
            defenderBuilder = new DefenderBuilder();
            vampireBuilder = new VampireBuilder();
            lancerBuilder = new LancerBuilder();
            healerBuilder = new HealerBuilder();
            assortedWarriors = new Warrior[]
            {
               trainer.Create(warriorBuilder),
               trainer.Create(warriorBuilder),
               trainer.Create(knightBuilder),
               trainer.Create(defenderBuilder),
               trainer.Create(vampireBuilder),
               trainer.Create(lancerBuilder),
               trainer.Create(healerBuilder)
            };
        }

        [Test]
        public void CreatingRank_NoParams_ReturnsTrue()
        {
            //Arrange
            Rank rank;
            int expectedCount;
            int actualCount;

            //Act
            rank = new Rank();
            expectedCount = 0;
            actualCount = rank.Count;

            //Assert
            Assert.IsNotNull(rank);
            Assert.IsFalse(rank.IsAlive);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CreatingRank_WithIEnumerable_ReturnsTrue()
        {
            //Arrange
            Rank rank;
            int expectedCount;
            int actualCount;

            //Act
            rank = new Rank(assortedWarriors);
            expectedCount = assortedWarriors.Length;
            actualCount = rank.Count;

            //Assert
            Assert.IsNotNull(rank);
            Assert.IsTrue(rank.IsAlive);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingUnit_EmptyRankOneUnit_ReturnsTrue()
        {
            //Arrange
            Rank rank;
            int expectedCount;
            int actualCount;

            //Act
            rank = new Rank();
            rank.AddUnit(assortedWarriors[0]);
            expectedCount = 1;
            actualCount = rank.Count;

            //Assert
            Assert.AreEqual(rank.FirstUnit, assortedWarriors[0]);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingUnit_EmptyRankArrayOfUnits_ReturnsTrue()
        {
            //Arrange
            Rank rank;

            //Act
            rank = new Rank();
            rank.AddUnit(assortedWarriors);

            //Assert
            CollectionAssert.AreEqual(assortedWarriors, rank);
        }

        [Test]
        public void AddingUnit_NotEmptyRankArrayOfUnits_ReturnsTrue()
        {
            //Arrange
            Rank rank;
            int expectedCount;
            int actualCount;

            //Act
            rank = new Rank(new Warrior[] { trainer.Create(knightBuilder), trainer.Create(warriorBuilder) });
            int startCount = rank.Count;
            rank.AddUnit(assortedWarriors);
            expectedCount = startCount + assortedWarriors.Length;
            actualCount = rank.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }

    [TestFixture]
    class ArmyTests
    {
        ArmyUnitTrainer trainer;
        WarriorBuilder warriorBuilder;
        KnightBuilder knightBuilder;
        DefenderBuilder defenderBuilder;
        VampireBuilder vampireBuilder;
        LancerBuilder lancerBuilder;
        HealerBuilder healerBuilder;
        Rank[] ranks;

        [SetUp]
        public void SetUp()
        {
            trainer = new ArmyUnitTrainer();
            warriorBuilder = new WarriorBuilder();
            knightBuilder = new KnightBuilder();
            defenderBuilder = new DefenderBuilder();
            vampireBuilder = new VampireBuilder();
            lancerBuilder = new LancerBuilder();
            healerBuilder = new HealerBuilder();
            ranks = new Rank[]
            {
                new Rank(new Warrior[]{ trainer.Create(lancerBuilder), trainer.Create(healerBuilder)}),
                new Rank(new Warrior[]{ trainer.Create(vampireBuilder) }),
                new Rank(new Warrior[]{ trainer.Create(knightBuilder), trainer.Create(warriorBuilder), trainer.Create(warriorBuilder) }),
                new Rank(new Warrior[]{ trainer.Create(defenderBuilder), trainer.Create(healerBuilder) }),
                new Rank(new Warrior[]{ trainer.Create(defenderBuilder) })
            };
        }

        [Test]
        public void CreatingArmy_NoParams_ReturnsTrue()
        {
            //Arrange
            Army army;
            int expectedCount;
            int actualCount;

            //Act
            army = new Army();
            expectedCount = 0;
            actualCount = army.Count;

            //Assert
            Assert.IsNotNull(army);
            Assert.IsFalse(army.IsAlive);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CreatingArmy_WithIEnumerable_ReturnsTrue()
        {
            //Arrange
            Army army;
            int expectedCount;
            int actualCount;

            //Act
            army = new Army(ranks);
            expectedCount = ranks.Length;
            actualCount = army.Count;

            //Assert
            Assert.IsNotNull(army);
            Assert.IsTrue(army.IsAlive);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingRank_EmptyArmyOneRank_ReturnsTrue()
        {
            //Arrange
            Army army;
            int expectedCount;
            int actualCount;

            //Act
            army = new Army();
            army.AddRank(ranks[0]);
            expectedCount = 1;
            actualCount = army.Count;

            //Assert
            Assert.AreEqual(army[0], ranks[0]);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingRank_EmptyArmyArrayOfRanks_ReturnsTrue()
        {
            //Arrange
            Army army;

            //Act
            army = new Army();
            army.AddRank(ranks);

            //Assert
            CollectionAssert.AreEqual(ranks, army);
        }

        [Test]
        public void AddingRank_EmptyArmyArrayOfUnits_ReturnsTrue()
        {
            //Arrange
            Army army;
            Warrior[] warriors = new Warrior[ranks[0].Count];
            for(int i = 0; i < warriors.Length; i++)
            {
                warriors[i] = ranks[0][i];
            }

            //Act
            army = new Army();
            army.AddRank(warriors);

            //Assert
            CollectionAssert.AreEqual(warriors, army[0]);
        }

        [Test]
        public void AddingRank_NotEmptyArmyArrayOfRanks_ReturnsTrue()
        {
            //Arrange
            Army army;
            int expectedCount;
            int actualCount;

            //Act
            army = new Army();
            army.AddRank(new Rank(new Warrior[] { trainer.Create(knightBuilder), trainer.Create(warriorBuilder) }));
            int startCount = army.Count;
            army.AddRank(ranks);
            expectedCount = startCount + ranks.Length;
            actualCount = army.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingToRank_NotEmptyArmyOneRank_ReturnsTrue()
        {
            //Arrange
            Army army;
            int expectedCount;
            int actualCount;

            //Act
            army = new Army(ranks);
            expectedCount = ranks[0].Count + 2;
            army.AddToRank(new Rank(new Warrior[] { trainer.Create(knightBuilder), trainer.Create(warriorBuilder) }), 0);
            actualCount = army[0].Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingToRank_NotEmptyArmyArrayOfUnits_ReturnsTrue()
        {
            //Arrange
            Army army;
            int expectedCount;
            int actualCount;

            //Act
            army = new Army(ranks);
            expectedCount = ranks[0].Count + ranks[1].Count;
            army.AddToRank(ranks[1], 0);
            actualCount = army[0].Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingToRank_NotEmptyArmyArrayOfUnitsWhrongIndex_ThrowsException()
        {
            //Arrange
            Army army;
            int expectedCount;
            int actualCount;

            //Act
            void TryAddingToRank()
            {
                army = new Army(ranks);
                army.AddToRank(ranks[1], ranks.Length);
                expectedCount = ranks[0].Count + ranks[1].Count;
                actualCount = army[0].Count;
            }

            //Assert
            Assert.Catch(typeof(ArgumentOutOfRangeException), TryAddingToRank);
        }
    }

    [TestFixture]
    class BattleTests 
    {
        Battle battle;
        Army army1;
        Army army2;
        ArmyUnitTrainer trainer;
        WarriorBuilder warriorBuilder;
        KnightBuilder knightBuilder;
        DefenderBuilder defenderBuilder;
        VampireBuilder vampireBuilder;
        LancerBuilder lancerBuilder;
        HealerBuilder healerBuilder;
        Warrior[] assortedWarriors;

        [SetUp]
        public void SetUp()
        {
            battle = new Battle();
            trainer = new ArmyUnitTrainer();
            warriorBuilder = new WarriorBuilder();
            knightBuilder = new KnightBuilder();
            defenderBuilder = new DefenderBuilder();
            vampireBuilder = new VampireBuilder();
            lancerBuilder = new LancerBuilder();
            healerBuilder = new HealerBuilder();
            assortedWarriors = new Warrior[]
            {
               trainer.Create(warriorBuilder),
               trainer.Create(warriorBuilder),
               trainer.Create(knightBuilder),
               trainer.Create(defenderBuilder),
               trainer.Create(vampireBuilder),
               trainer.Create(lancerBuilder),
               trainer.Create(healerBuilder)
            };
            army1 = new Army();
            army2 = new Army();
        }

        [Test]
        public void Fight1v1_WarriorVsWarrior_ReturnsTrue()
        {
            //Arrange
            bool result;
            Warrior warrior;

            //Act
            warrior = trainer.Create(warriorBuilder);
            result = battle.Fight(warrior, assortedWarriors[(int)WarriorType.Warrior]);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Fight1v1_WarriorVsKnight_ReturnsFalse()
        {
            //Arrange
            bool result;

            //Act
            result = battle.Fight(assortedWarriors[(int)WarriorType.Warrior], assortedWarriors[(int)WarriorType.Knight]);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Fight1v1_WarriorVsDefender_ReturnsFalse()
        {
            //Arrange
            bool result;

            //Act
            result = battle.Fight(assortedWarriors[(int)WarriorType.Warrior], assortedWarriors[(int)WarriorType.Defender]);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Fight1v1_DefenderVsVampire_ReturnsTrue()
        {
            //Arrange
            bool result;

            //Act
            result = battle.Fight(assortedWarriors[(int)WarriorType.Defender], assortedWarriors[(int)WarriorType.Vampire]);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Fight1v1_VampireVsWarrior_ReturnsTrue()
        {
            //Arrange
            bool result;

            //Act
            result = battle.Fight(assortedWarriors[(int)WarriorType.Vampire], assortedWarriors[(int)WarriorType.Warrior]);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsKnightAlive_AfterFightWarriorVsKnight_ReturnsTrue()
        {
            //Arrange
            bool battleResult;
            bool result;

            //Act
            battleResult = battle.Fight(assortedWarriors[(int)WarriorType.Warrior], assortedWarriors[(int)WarriorType.Knight]);
            result = assortedWarriors[(int)WarriorType.Knight].IsAlive;

            //Assert
            Assert.IsFalse(battleResult);
            Assert.IsTrue(result);
        }

        [Test]
        public void FightRankvsRank_LancerVsWarriorAndKnight_ReturnsFalse()
        {
            //Arrange
            bool result;
            int expectedCount;
            int actualCount;
            Rank rank1 = new Rank(new Warrior[]
            {
                trainer.Create(lancerBuilder)
            });
            Rank rank2 = new Rank(new Warrior[]
            {
                trainer.Create(warriorBuilder),
                trainer.Create(knightBuilder)
            });

            //Act
            result = battle.Fight(rank1, rank2);
            expectedCount = 1;
            actualCount = rank2.Count;

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FightRankvsRank_LancerVsWarriorAndHealer_ReturnsFalse()
        {
            //Arrange
            bool result;
            int expectedCount;
            int actualCount;
            Rank rank1 = new Rank(new Warrior[]
            {
                trainer.Create(lancerBuilder)
            });
            Rank rank2 = new Rank(new Warrior[]
            {
                trainer.Create(warriorBuilder),
                trainer.Create(healerBuilder)
            });

            //Act
            result = battle.Fight(rank1, rank2);
            expectedCount = 2;
            actualCount = rank2.Count;

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FightRankvsRank_LancerAndHealerVsWarriorAndHealer_ReturnsTrue()
        {
            //Arrange
            bool result;
            int expectedCount;
            int actualCount;
            Rank rank1 = new Rank(new Warrior[]
            {
                trainer.Create(lancerBuilder),
                trainer.Create(healerBuilder)
            });
            Rank rank2 = new Rank(new Warrior[]
            {
                trainer.Create(warriorBuilder),
                trainer.Create(healerBuilder)
            });

            //Act
            result = battle.Fight(rank1, rank2);
            expectedCount = 2;
            actualCount = rank1.Count;

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}