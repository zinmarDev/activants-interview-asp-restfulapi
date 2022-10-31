using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Interface
{
    public interface ISushiService
    {
        List<Sushi> GetSushis();
    }
}