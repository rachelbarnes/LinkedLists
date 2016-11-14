using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace LinkedLists {

    public class Cell<T> {
        public T value;
        public Cell<T> next;

        public Cell() { }

        public Cell(T _value, Cell<T> _next) {
            value = _value;
            next = _next;
        }

        public int CountIter() {
            var ret = 0;
            while (value != null) {
                ret++;
            }
            return ret;
        }

        public string PrintCellRec() {
            var ret = ""; 
            if (next == null) {
                ret += value.ToString(); 
            }
            if (next != null) {
                ret += value.ToString() + " -> " + next.PrintCellRec(); 
            }
            return ret; 
        }

        public int CountCellRec() {
            var ret = 0; 
            if (next == null) {
                ret += 1; 
            }
            if (next != null) {
                ret += 1 + next.CountCellRec(); 
            }
            return ret; 
        }
    }
    public class CellHelper<T> {

        public int CountIterWParm(Cell<T> n) {
            var ret = 0;
            while (n != null) {
                ret++;
                n = n.next;
            }
            return ret;
        }

        public string PrintCellString(Cell<T> n) {
            var ret = "";
            while (n != null) {
                if (n.next == null) {
                    ret += n.value.ToString();
                }
                if (n.next != null) {
                    ret += n.value.ToString() + " -> ";
                }
                n = n.next;
            }
            return ret;
        }

        public string PrintCellStringRecWithParam(Cell<T> n) {
            var ret = ""; 
            if (n.next != null) {
                ret += n.value.ToString() + " -> " + PrintCellStringRecWithParam(n.next);  
            }
            if (n.next == null) {
                ret += n.value.ToString(); 
            }
            return ret; 
        }
        
        public int CountCellRecwithParm(Cell<T> n) {
            var ret = 0;
            if (n.next != null){
                ret += 1 + CountCellRecwithParm(n.next); 
            }
            if (n.next == null) {
                ret += 1; 
            }
            return ret; 
        }

        //public string PrintCellRec() {
        //    var ret = ""; 
        //    if (next != null) {
        //        ret += n.value.ToString() + " -> " + PrintCellRec(); 
        //    }
        //}

        //I started to do the above method, but I don't think I can do this without the parameters if I'm outside of the cell class, 
            //there's no where to call the method unless I create an instance of the Cell<T> class
    }


    [TestFixture]
    public class CellTests {
        [Test]
        public void CountTest() {
            var x = new Cell<int>(1, new Cell<int>(2, new Cell<int>(4, new Cell<int>(7, new Cell<int>(8, null)))));
            var expected = 5;
            var actual = x.CountIter();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CountTestParam() {
            var count = new CellHelper<int>();
            var x = new Cell<int>(1, new Cell<int>(2, new Cell<int>(4, new Cell<int>(7, new Cell<int>(8, null)))));
            var expected = 5;
            var actual = count.CountIterWParm(x);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void PrintCellHelperFunction() {
            var count = new CellHelper<int>(); 
            var x = new Cell<int>(1, new Cell<int>(2, new Cell<int>(4, new Cell<int>(7, new Cell<int>(8, null)))));
            var expected = "1 -> 2 -> 4 -> 7 -> 8";
            var actual = count.PrintCellString(x);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RecursivePrintHelperFunction() {
            var count = new CellHelper<int>();
            var x = new Cell<int>(1, new Cell<int>(2, new Cell<int>(4, new Cell<int>(7, new Cell<int>(8, null)))));
            var expected = "1 -> 2 -> 4 -> 7 -> 8";
            var actual = count.PrintCellStringRecWithParam(x);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CountRecTestParam() {
            var count = new CellHelper<int>();
            var x = new Cell<int>(1, new Cell<int>(2, new Cell<int>(4, new Cell<int>(7, new Cell<int>(8, null)))));
            var expected = 5;
            var actual = count.CountCellRecwithParm(x);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RecPrintHelperNoParam() {
            var x = new Cell<int>(1, new Cell<int>(2, new Cell<int>(4, new Cell<int>(7, new Cell<int>(8, null)))));
            var expected = "1 -> 2 -> 4 -> 7 -> 8";
            var actual = x.PrintCellRec();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CountRecTest() {
            var x = new Cell<int>(1, new Cell<int>(2, new Cell<int>(4, new Cell<int>(7, new Cell<int>(8, null)))));
            var expected = 5;
            var actual = x.CountCellRec();
            Assert.AreEqual(expected, actual);
        }
    }
}
