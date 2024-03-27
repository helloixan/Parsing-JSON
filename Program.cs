using System.Runtime.CompilerServices;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        //Contoh object yang akan ditulis dalam JSON
        ContohClassMahasiswa mahasiswa = new ContohClassMahasiswa("IksanRisandy", "1302223042", 3.98);
        MyJSON myJSON = new MyJSON();
        //myJSON.WriteJSON(mahasiswa);
        myJSON.ReadJSON();
    }
}


public class ContohClassMahasiswa
{
    public String nama { get; set; }
    public String nim { get; set; }
    public double ipk { get; set; }
    public ContohClassMahasiswa(String nama, String nim, double ipk)
    {
        this.nama = nama;
        this.nim = nim;
        this.ipk = ipk;
    }
}

public class MyJSON()
{
    private String filepath = "C:/Users/iksan/source/repos/week6_parsing/json/DataMahasiswa.json";

    public void WriteJSON<Objek>(Objek objek)
    {
        //[Opsional] Merapikan format JSON
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        //Melakukan perubahan object menjadi string(Serialization)
        String jsonString = JsonSerializer.Serialize(objek, options);
        Console.WriteLine(jsonString);
        //Membuat file JSON yg berisi string hasil serialization
        File.WriteAllText(filepath, jsonString);
    }

    public void ReadJSON()
    {
        //Baca file Json yang diinginkan
        String jsonString = File.ReadAllText(filepath);
        //Deserialize file json menjadi object
        ContohClassMahasiswa mahasiswa = JsonSerializer.Deserialize<ContohClassMahasiswa>(jsonString);
        Console.WriteLine("Nama :" + mahasiswa.nama);
        Console.WriteLine("NIM :" + mahasiswa.nim);
        Console.WriteLine("IPK :" + mahasiswa.ipk);
    }

}