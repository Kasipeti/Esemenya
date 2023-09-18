namespace DocuStat
{
    internal class Program
    {
        static int Main(string[] args)
        {
            string path;
            do 
            {
                Console.WriteLine( "Please enter the file path: " );
                path = Console.ReadLine() ?? ""; // ha nullérték az in akkor üres string

            }while(System.IO.Path.GetExtension(path) !=".txt" || !System.IO.File.Exists(path) );
            //System.IO.Path.GetExtension(path) visszadtja az adott fájl kiterjesztését
            //System.IO.File.Exists(path) megnézi h létezik e az adott fájl a gépen.
            Model stat=new Model(path);
            try
            {
                stat.Load();
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine("The file cannot be opened");
                Console.WriteLine(ex.Message);
                return -1;

            }
           int minOccurreence =1; int minLenght = 5;
            int maxLenght = 12;
            var pairs = stat.DistinctWordCount.
                Where(p => p.Value >= minOccurreence).
                Where(p => p.Key.Length >= minLenght).
                Where(p => p.Key.Length <= maxLenght);
            foreach (var pair in pairs) 
            { Console.WriteLine( $"{pair.Key}:{pair.Value}"   );
                 
            }

            return 0;
            
        }
    }
}