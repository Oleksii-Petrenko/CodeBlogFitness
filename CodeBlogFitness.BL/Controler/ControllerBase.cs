﻿using System.Collections.Generic;


namespace CodeBlogFitness.BL.Controler
{
    public abstract class ControllerBase
    {
        private readonly IDatasaver manager = new SerializeDataSaver();

        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();

        }

    }
}
