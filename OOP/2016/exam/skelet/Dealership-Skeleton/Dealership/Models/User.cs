using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;
using Dealership.Common;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string password;
        private string username;
        private IList<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password, string role = "Normal")
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.SetRole(role);
            this.vehicles = new List<IVehicle>();
        }

        private void ValidateName(string name, int valueLen)
        {
            string exceptionMessage = string.Format(
                Constants.StringMustBeBetweenMinAndMax,
                name,
                Constants.MinNameLength,
                Constants.MaxNameLength);

            Validator.ValidateIntRange(
                valueLen,
                Constants.MinNameLength,
                Constants.MaxNameLength,
                exceptionMessage
                );
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                this.ValidateName("Firstname", value.Length);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                this.ValidateName("Lastname", value.Length);
                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            private set
            {
                string exceptionMessage = string.Format(
                Constants.StringMustBeBetweenMinAndMax,
                "Password",
                Constants.MinPasswordLength,
                Constants.MaxPasswordLength);

                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinPasswordLength,
                    Constants.MaxPasswordLength,
                    exceptionMessage
                    );

                Validator.ValidateSymbols(value, Constants.PasswordPattern, string.Format( Constants.InvalidSymbols, "Password"));
                this.password = value;
            }
        }

        public Role Role { get; private set; }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                this.ValidateName("Username", value.Length);
                Validator.ValidateSymbols(value, Constants.UsernamePattern, string.Format(Constants.InvalidSymbols, "Username"));
                this.username = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            //get { return new List<IVehicle>(this.vehicles); }
            get { return this.vehicles; }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            Validator.ValidateNull(commentToAdd, Constants.CommentCannotBeNull);
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (this.Role == Role.Admin)
            {
                throw new Exception(Constants.AdminCannotAddVehicles);
            }
            else if (this.Role == Role.Normal && this.vehicles.Count == Constants.MaxVehiclesToAdd)
            {
                throw new Exception(string.Format(Constants.NotAnVipUserVehiclesAdd, Constants.MaxVehiclesToAdd));
            }
            else
            {
                Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);
                this.vehicles.Add(vehicle);
            }
        }

        public string PrintVehicles()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("--USER {0}--", this.Username));
            if (this.vehicles.Count == 0)
            {
                sb.AppendLine("--NO VEHICLES--");
            }
            else
            {
                for (int i = 0; i < this.vehicles.Count; i++)
                {
                    sb.AppendLine(string.Format("{0}. {1}", i + 1, vehicles[i].ToString()));
                }
            }
            return sb.ToString().TrimEnd();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove.Author != this.Username)
            {
                throw new Exception(Constants.YouAreNotTheAuthor);
            }
            else
            {
                vehicleToRemoveComment.Comments.Remove(commentToRemove);
            }
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            string userToString = string.Format(Constants.UserToString, this.Username, this.FirstName, this.LastName);
            return string.Format("{0}, Role: {1}", userToString, this.Role.ToString());
        }

        private void SetRole(string role = null)
        {
            switch (role)
            {
                case "VIP":
                    this.Role = Role.VIP;
                    break;
                case "Admin":
                    this.Role = Role.Admin;
                    break;
                default:
                    this.Role = Role.Normal;
                    break;
            }
        }
    }
}
