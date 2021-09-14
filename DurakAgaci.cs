using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
//Tuğcan Topaloğlu -05190000072
namespace ds_project_3
{
    class Node<Durak>
    {
        public Node<Durak> SolNode { get; set; }
        public Node<Durak> SagNode { get; set; }
        public Durak Data { get; set; }
    }

    class DurakAgaci
    {
        CultureInfo tr = new CultureInfo("tr-TR"); //Türkçe karakterler için sıralama şartları
        public Node<Durak> Root { get; set; }

        public bool Ekle(Durak value)
        {
            Node<Durak> before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value.durakAdi.CompareTo(after.Data.durakAdi)==-1 ) 
                    after = after.SolNode;
                else if (value.durakAdi.CompareTo(after.Data.durakAdi) == +1) 
                    after = after.SagNode;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            Node<Durak> newNode = new Node<Durak>();
            newNode.Data = value;

            if (this.Root == null)//Ağaç boş ise
                this.Root = newNode;
            else
            {
                if (value.durakAdi.CompareTo(before.Data.durakAdi) == -1)
                    before.SolNode = newNode;
                else
                    before.SagNode = newNode;
            }

            return true;
        }

        public Node<Durak> Bul(Durak value)
        {
            return this.Bul(value, this.Root);
        }

        public void Kaldir(Durak value)
        {
            this.Root = Kaldir(this.Root, value);
        }

        private Node<Durak> Kaldir(Node<Durak> parent, Durak key)
        {
            if (parent == null) return parent;

            if (key.durakAdi.CompareTo(parent.Data.durakAdi)==-1) parent.SolNode = Kaldir(parent.SolNode, key);
            else if (key.durakAdi.CompareTo(parent.Data.durakAdi) == +1)
                parent.SagNode = Kaldir(parent.SagNode, key);

            // eğer değer parent değeri ile aynıysa bu node silinecek demektir 
            else
            {
                // Tek node'a bağlı veya hiçbir node'a bağlı olmayan node'u silmek 
                if (parent.SolNode == null)
                    return parent.SagNode;
                else if (parent.SagNode == null)
                    return parent.SolNode;

                // 2 farklı node'a bağlı olan nodu silme işlemi (node with two children)  
                parent.Data = MinDeger(parent.SagNode);

                // Varisini sıralı olarak sil  
                parent.SagNode = Kaldir(parent.SagNode, parent.Data);
            }

            return parent;
        }

        private Durak MinDeger(Node<Durak> node)
        {
            Durak minv = node.Data;

            while (node.SolNode != null)
            {
                minv = node.SolNode.Data;
                node = node.SolNode;
            }

            return minv;
        }

        private Node<Durak> Bul(Durak value, Node<Durak> parent)
        {
            if (parent != null)
            {
                if (value.durakAdi.CompareTo(parent.Data.durakAdi) == 0) return parent;
                if (value.durakAdi.CompareTo(parent.Data.durakAdi) == -1)
                    return Bul(value, parent.SolNode);
                else
                    return Bul(value, parent.SagNode);
            }

            return null;
        }

        public int AgacDerinliginiAl()
        {
            return this.AgacDerinliginiAl(this.Root);
        }

        private int AgacDerinliginiAl(Node<Durak> parent)
        {
            return parent == null ? 0 : Math.Max(AgacDerinliginiAl(parent.SolNode), AgacDerinliginiAl(parent.SagNode)) + 1;
        }

        public void TraversePreOrder(Node<Durak> parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.SolNode);
                TraversePreOrder(parent.SagNode);
            }
        }

        public void TraverseInOrder(Node<Durak> parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.SolNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.SagNode);
            }
        }

        public void TraversePostOrder(Node<Durak> parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.SolNode);
                TraversePostOrder(parent.SagNode);
                Console.Write(parent.Data + " ");
            }
        }
    }
}