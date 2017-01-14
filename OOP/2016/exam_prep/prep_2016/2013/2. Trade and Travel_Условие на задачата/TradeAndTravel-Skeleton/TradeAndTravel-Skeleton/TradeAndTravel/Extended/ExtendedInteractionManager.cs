using System;

namespace TradeAndTravel.Extended
{
    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            if (item != null)
            {
                return item;
            }
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
            }
            return item;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person basePerson = base.CreatePerson(personTypeString, personNameString, personLocation);
            if (basePerson != null)
            {
                return basePerson;
            }

            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    break;
            }
            return person;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location baseLocation = base.CreateLocation(locationTypeString, locationName);
            if (baseLocation != null)
            {
                return baseLocation;
            }

            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "craft":
                    HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
                    break;
                case "gather":
                    HandleGatherpInteraction(actor, commandWords[2]);
                    break;
            }
            base.HandlePersonCommand(commandWords, actor);
        }

        private void HandleGatherpInteraction(Person actor, string itemName)
        {
            if (actor.Location.LocationType == LocationType.Forest)
            {
                var inventory = actor.ListInventory();
                bool hasWeapon = false;
                foreach (var item in inventory)
                {
                    if (item.ItemType == ItemType.Weapon)
                    {
                        hasWeapon = true;
                    }
                }
                if (hasWeapon)
                {
                    this.AddToPerson(actor, new Wood(itemName, actor.Location));
                }
            }
            else if (actor.Location.LocationType == LocationType.Mine)
            {
                var inventory = actor.ListInventory();
                bool hasArmor = false;
                foreach (var item in inventory)
                {
                    if (item.ItemType == ItemType.Armor)
                    {
                        hasArmor = true;
                    }
                }
                if (hasArmor)
                {
                    this.AddToPerson(actor, new Wood(itemName, actor.Location));
                }
            }
        }

        private void HandleCraftInteraction(Person actor, string itemType, string itemName)
        {
            var inventory = actor.ListInventory();
            bool hasIron = false;
            bool hasWood = false;
            foreach (var item in inventory)
            {
                if (item.ItemType == ItemType.Iron || item.ItemType == ItemType.Armor)
                {
                    hasIron = true;
                }
                else if (item.ItemType == ItemType.Wood)
                {
                    hasWood = true;
                }
            }
            if (itemType == "weapon" && hasIron && hasWood)
            {
                this.AddToPerson(actor, new Weapon(itemName, actor.Location));
            }
            else if (itemType == "armor" && hasIron)
            {
                this.AddToPerson(actor, new Armor(itemName, actor.Location));
            }
        }
    }
}
