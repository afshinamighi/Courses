

namespace Exercise
{
    public class Examples
    {
        public void runExamples()
        {
            ThreadsList tl = new ThreadsList();
            // todo 1: uncomment this and check the execution
//            tl.runExample();

            ThreadCreation tc = new ThreadCreation();
            // todo 2: uncomment this and check the execution
            tc.runExample();

            ThreadsJoin tj = new ThreadsJoin(2000);
            // todo 3: uncomment this and check the execution 
//            tj.runExample();
        }
    }
}
