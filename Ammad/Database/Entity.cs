using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Ammad.Database
{
    [Database]
    public abstract class Entity
    {
        public string ObId => this.GetObjectID();
    }
}
