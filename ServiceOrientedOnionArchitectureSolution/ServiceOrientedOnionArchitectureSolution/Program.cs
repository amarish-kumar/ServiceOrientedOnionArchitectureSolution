﻿using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Modules;

using BL.Interfaces;
using DependencyResolution;

namespace ServiceOrientedOnionArchitectureSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = CreateKernel();
            
            var playerService = kernel.Get<IPlayerService>();
            var playerManagementService = kernel.Get<IPlayerManagementService>();

            Console.WriteLine(playerService.Play());
            Console.WriteLine(playerManagementService.GetFirstPlayer().Name);
        }

        public static IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();
            var modules = new List<INinjectModule>
            {
                new RepositoriesModule(),
                new ServicesModule()
            };

            kernel.Load(modules);
            return kernel;
        }
    }
}
