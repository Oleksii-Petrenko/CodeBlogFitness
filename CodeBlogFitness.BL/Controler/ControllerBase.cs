

namespace CodeBlogFitness.BL.Controler
{
    public abstract class ControllerBase
    {
        protected IDatasaver saver = new SerializeDataSaver();


        protected void Save(string fileName, object item)
        {
            saver.Save(fileName, item);

        }

        protected T Load<T>(string fileName)
        {
            return saver.Load<T>(fileName);
            
        }

    }
}
