using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class myHoldingPen : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            base.ExecuteInsertUnitCommand(commandWords);
            switch (commandWords[1])
            {
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                default:
                    break;
            }
        }
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "PowerCatalyst":
                    var powerCatalyst = new PowerCatalyst();
                    this.GetUnit(commandWords[2]).AddSupplement(powerCatalyst);
                    break;
                case "HealthCatalyst":
                    var healthCatalyst = new HealthCatalyst();
                    this.GetUnit(commandWords[2]).AddSupplement(healthCatalyst);
                    break;
                case "AggressionCatalyst":
                    var aggressionCatalyst = new AggressionCatalyst();
                    this.GetUnit(commandWords[2]).AddSupplement(aggressionCatalyst);
                    break;
                case "Weapon":
                    Weapon weapon = new Weapon();
                    this.GetUnit(commandWords[2]).AddSupplement(weapon);
                    break;
                default:
                    break;
            }
        }
        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                    Unit sourceUnit = this.GetUnit(interaction.SourceUnit);
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }
    }
}
