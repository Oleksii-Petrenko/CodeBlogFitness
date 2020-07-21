using System.Collections.Generic;

namespace CodeBlogFitness.BL.Controler
{
    public interface IDatasaver
    {
        void Save<T>(List<T> item) where T : class;

        List<T> Load<T>() where T : class;

    }
}