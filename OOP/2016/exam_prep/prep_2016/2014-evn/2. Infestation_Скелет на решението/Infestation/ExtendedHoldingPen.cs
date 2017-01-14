namespace Infestation
{
    class ExtendedHoldingPen : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "PowerCatalyst":
                    this.GetUnit(commandWords[2]).AddSupplement(new PowerCatalyst());
                    break;
                case "HealthCatalyst":
                    this.GetUnit(commandWords[2]).AddSupplement(new HealthCatalyst());
                    break;
                case "AggressionCatalyst":
                    this.GetUnit(commandWords[2]).AddSupplement(new AggressionCatalyst());
                    break;
                case "Weapon":
                    this.GetUnit(commandWords[2]).AddSupplement(new Weapon());
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
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }

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
    }
}
