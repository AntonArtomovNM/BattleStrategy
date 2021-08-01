using System;
using BattleStrategy.Warriors;
using BattleStrategy.Battles;
using BattleStrategy.Visualizers;
using System.Threading.Tasks;

namespace BattleStrategy
{
    class Program
    {

        static void Main(string[] args)
        {
            Battle battle = new Battle();
            ConsoleVisualizer cv = new ConsoleVisualizer();
            ArmyUnitTrainer trainer = new ArmyUnitTrainer();
            WarriorBuilder wb = new WarriorBuilder();
            KnightBuilder kb = new KnightBuilder();
            DefenderBuilder db = new DefenderBuilder();
            VampireBuilder vb = new VampireBuilder();
            LancerBuilder lb = new LancerBuilder();
            HealerBuilder hb = new HealerBuilder();
            //Warrior[] warriors = new Warrior[]
            //{
            //    ArmyUnitTrainer.Train(wb),
            //    ArmyUnitTrainer.Train(kb),
            //    ArmyUnitTrainer.Train(wb),
            //    ArmyUnitTrainer.Train(wb)
            //};
            //Army army = new Army(warriors);

            //Console.WriteLine(army);
            //Console.WriteLine(army.IsAlive);
            var warrior = trainer.Create(wb);
            var knight = trainer.Create(kb);
            var defender = trainer.Create(db);
            var vampire = trainer.Create(vb);
            var lancer = trainer.Create(lb);
            var healer = trainer.Create(hb);
            //Console.WriteLine(battle.Fight(vampire, warrior));

            //Arrange
            bool result;
            int expectedCount;
            int actualCount;
            Rank rank1 = new Rank(new Warrior[] { lancer }, "Left");
            Rank rank2 = new Rank(new Warrior[] { warrior, healer }, "Right");
            Army army1 = new Army(new Rank[]
            {
                rank1,
                new Rank(new Warrior[] {defender, vampire, trainer.Create(wb)})
            }, "Left");
            Army army2 = new Army(new Rank[]
            {
                rank2,
                new Rank(new Warrior[] {trainer.Create(lb), knight})
            }, "Right");
            //Act
            //result = battle.Fight(rank1, rank2, cv);
            //cv.ShowBattle(army1, army2);
            result = battle.Fight(army1, army2, cv);
            expectedCount = 2;
            actualCount = army2.Count;

            //Assert
            //Console.WriteLine(rank1);
            //Console.WriteLine(rank2);
            Console.WriteLine(result);
            lancer.ShowInfo(cv);
            knight.ShowInfo(cv);
            healer.ShowInfo(cv);
        }
    }
}
