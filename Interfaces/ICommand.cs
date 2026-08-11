using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
namespace Quaq.Interfaces;

public interface IComando
{
    public Command Get();
}