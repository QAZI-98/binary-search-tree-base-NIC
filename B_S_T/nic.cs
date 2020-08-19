using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_S_T
{
    class nod
    {
        public nod right;
        public nod left;
        public int key;
        public string name;
        public string dob;
        public string adress;
        public int age;
        public nod(int _key,string _name,string _dob,string _adress)
        {
            key = _key;
            name = _name;
            dob = _dob;
            adress = _adress;
           
        }


    }

    class nic
    {

        public nod root = null;

        public void insert(nod node, int value,string name,string dob,string adress)
        {
            if (root==null)
            {
                root = new nod(value,name,dob,adress);
            }
            else 
            {
            if (value <= node.key)
            {
                if (node.left != null)
                {
                    insert(node.left, value,name,dob,adress);
                }
                else
                {
                    node.left = new nod(value,name,dob,adress);
                }
            }
            else if (value > node.key)
            {
                if (node.right != null)
                {
                    insert(node.left, value, name, dob, adress);
                }
                else
                {
                    node.right = new nod(value, name, dob, adress);
                }
            }
        }
        }

        public nod search_recursively(int _key, nod rev)
        {
            if (rev == null)
            {
                return null;
            }
            if (_key == rev.key)
            {
                return rev;
            }
            if (rev.key > _key)
            {
                return search_recursively(_key, rev.left);

            }
            else
            {
                return search_recursively(_key, rev.right);
            }

        }



        public void in_order_traverse(nod rut)
        {
            if (rut!=null)
            {
                in_order_traverse(rut.left);
                Console.WriteLine("\t" + rut.key + "\t\t" + rut.name + "\t" + rut.dob + "\t" + rut.adress);
                in_order_traverse(rut.right);
            }
        }





    }







}
