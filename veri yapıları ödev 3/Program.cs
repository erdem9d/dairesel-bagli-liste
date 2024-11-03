using System;

public class Node
{
    public int Data; // Düğümün taşıdığı veri
    public Node Next; // Bir sonraki düğüme işaret eden referans

    public Node(int data)
    {
        Data = data; // Düğüm oluşturulduğunda veriyi ayarlıyoruz
        Next = null; // Başlangıçta sonraki düğüm boş
    }
}

public class CircularLinkedList
{
    private Node head = null; // Listenin başlangıç düğümü

    // Listenin başına yeni bir düğüm ekleme
    public void AddFirst(int data)
    {
        Node newNode = new Node(data); // Yeni düğümü oluştur
        if (head == null) // Eğer liste boşsa
        {
            head = newNode; // Baş düğüm olarak yeni düğümü ayarla
            newNode.Next = head; // Düğüm kendisini işaret etsin
        }
        else // Liste dolu ise
        {
            Node temp = head;
            while (temp.Next != head) // Son düğüme kadar git
            {
                temp = temp.Next;
            }
            temp.Next = newNode; // Son düğümün Next'ini yeni düğüme ayarla
            newNode.Next = head; // Yeni düğümün Next'ini baş düğüme işaret et
            head = newNode; // Yeni düğümü baş düğüm yap
        }
    }

    // Listenin sonuna yeni bir düğüm ekleme
    public void AddLast(int data)
    {
        Node newNode = new Node(data); // Yeni düğümü oluştur
        if (head == null) // Eğer liste boşsa
        {
            head = newNode; // Baş düğüm olarak yeni düğümü ayarla
            newNode.Next = head; // Düğüm kendisini işaret etsin
        }
        else // Liste dolu ise
        {
            Node temp = head;
            while (temp.Next != head) // Son düğüme kadar git
            {
                temp = temp.Next;
            }
            temp.Next = newNode; // Son düğümün Next'ini yeni düğüme ayarla
            newNode.Next = head; // Yeni düğümün Next'ini baş düğüme işaret et
        }
    }

    // İstenilen sırada yeni bir düğüm ekleme
    public void AddAt(int index, int data)
    {
        if (index == 0) // Eğer ekleme yeri baş ise
        {
            AddFirst(data); // Başta ekleme yap
            return;
        }

        Node newNode = new Node(data); // Yeni düğümü oluştur
        Node temp = head;
        for (int i = 0; i < index - 1 && temp.Next != head; i++) // İstenilen sıraya gelene kadar git
        {
            temp = temp.Next;
        }

        newNode.Next = temp.Next; // Yeni düğümün Next'ini uygun yere ayarla
        temp.Next = newNode; // Önceki düğümün Next'ini yeni düğüme işaret et
    }

    // Listenin başındaki düğümü silme
    public void RemoveFirst()
    {
        if (head == null) return; // Eğer liste boşsa hiçbir şey yapma

        if (head.Next == head) // Eğer sadece bir düğüm varsa
        {
            head = null; // Baş düğümü sıfırla
        }
        else // Daha fazla düğüm varsa
        {
            Node temp = head;
            while (temp.Next != head) // Son düğüme kadar git
            {
                temp = temp.Next;
            }
            temp.Next = head.Next; // Son düğümün Next'ini baştaki düğümün Next'ine ayarla
            head = head.Next; // Baş düğümü bir sonraki düğüm yap
        }
    }

    // Listenin sonundaki düğümü silme
    public void RemoveLast()
    {
        if (head == null) return; // Eğer liste boşsa hiçbir şey yapma

        if (head.Next == head) // Eğer sadece bir düğüm varsa
        {
            head = null; // Baş düğümü sıfırla
            return;
        }

        Node temp = head;
        while (temp.Next.Next != head) // İkinci son düğüme kadar git
        {
            temp = temp.Next;
        }
        temp.Next = head; // İkinci son düğümün Next'ini baş düğüm yap
    }

    // İstenilen sıradaki düğümü silme
    public void RemoveAt(int index)
    {
        if (head == null) return; // Eğer liste boşsa hiçbir şey yapma

        if (index == 0) // Eğer silme yeri baş ise
        {
            RemoveFirst(); // Baştan silme yap
            return;
        }

        Node temp = head;
        for (int i = 0; i < index - 1 && temp.Next != head; i++) // İstenilen sıraya gelene kadar git
        {
            temp = temp.Next;
        }
        if (temp.Next != head) // Eğer düğüm mevcutsa
        {
            temp.Next = temp.Next.Next; // Önceki düğümün Next'ini uygun şekilde ayarla
        }
    }

    // Listeyi yazdırma
    public void PrintList()
    {
        if (head == null) return; // Eğer liste boşsa hiçbir şey yapma

        Node temp = head;
        do
        {
            Console.Write(temp.Data + " "); // Düğümün verisini yazdır
            temp = temp.Next; // Bir sonraki düğüme geç
        } while (temp != head); // Başlangıca dönene kadar devam et
        Console.WriteLine(); // Yeni satıra geç
    }
}

class Program
{
    static void Main()
    {
        CircularLinkedList list = new CircularLinkedList();

        list.AddFirst(10); // Listeye 10 ekle
        list.AddLast(20); // Listeye 20 ekle
        list.AddLast(30); // Listeye 30 ekle
        list.AddAt(1, 15); // 1. sıraya 15 ekle (10, 15, 20, 30)

        Console.WriteLine("Liste: ");
        list.PrintList(); // 10, 15, 20, 30 yazdır

        list.RemoveFirst(); // Baştaki düğümü sil
        Console.WriteLine("Baştan silindikten sonra liste: ");
        list.PrintList(); // 15, 20, 30 yazdır

        list.RemoveLast(); // Sondaki düğümü sil
        Console.WriteLine("Sondan silindikten sonra liste: ");
        list.PrintList(); // 15, 20 yazdır

        list.RemoveAt(1); // 1. sıradaki düğümü sil
        Console.WriteLine("İstenilen sırada silindikten sonra liste: ");
        list.PrintList(); // 15 yazdır
        Console.ReadLine();
    }
}
