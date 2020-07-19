
namespace CodeBlogFitness.BL.Controler
{
    public interface IDatasaver
    {
        void Save(string fileName, object item);

        T Load<T>(string fileName);

    }
}
