using System;
using System.Collections.Generic;
using System.Text;

namespace CharlaDDD.Domain.Core
{
    public abstract class Entity
    {
        public int Id { get; set; }

        /// <summary>
        /// Determina si una determinada Entidad es igual que otra instancia del mismo tipo en base a su Id.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            return item.Id == this.Id;
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right) => !(left == right);

        public override int GetHashCode() => this.Id.GetHashCode() ^ 31;
    }
}
