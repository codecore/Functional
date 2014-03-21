using System;
using System.Collections.Generic;

using Functional.Contracts;
namespace Functional.Implementation {
    public class Tuple<A,B> {
        private A a;
        private B b;

        private Tuple() { }
        private Tuple(A inA, B inB) { this.a = inA; this.b = inB; }

        public static A first(Tuple<A,B> t) { return t.a; }
        public static B second(Tuple<A,B> t) { return t.b; }

        public static Tuple<A, B> Create<A,B>(A inA, B inB) { return new Tuple<A,B>(inA, inB); }
        public static void Extract(ref A outA,ref B outB, Tuple<A, B> t) { outA = first(t); outB = second(t); }
    }
    public class Tuple<A,B,C> {
        private A a;
        private B b;
        private C c;
        private Tuple() { }
        private Tuple(A inA, B inB, C inC) { this.a = inA; this.b = inB; this.c = inC; }

        public static A first(Tuple<A,B,C> t) { return t.a; }
        public static B second(Tuple<A,B,C> t) { return t.b; }
        public static C third(Tuple<A,B,C> t) { return t.c; }

        public static Tuple<A,B,C> Create<A,B,C>(A inA, B inB, C inC) { return new Tuple<A,B,C>(inA, inB, inC); }
        public static void Extract(ref A outA,ref B outB,ref C outC, Tuple<A,B,C> t) { outA = first(t); outB = second(t); outC = third(t); }
    }
    public class Tuple<A,B,C,D> {
        private A a;
        private B b;
        private C c;
        private D d;
        private Tuple() { }
        private Tuple(A inA, B inB, C inC, D inD) { this.a = inA; this.b = inB; this.c = inC; this.d = inD; }

        public static A first(Tuple<A,B,C,D> t) { return t.a; }
        public static B second(Tuple<A,B,C,D> t) { return t.b; }
        public static C third(Tuple<A,B,C,D> t) { return t.c; }
        public static D fourth(Tuple<A,B,C,D> t) { return t.d; }

        public static Tuple<A,B,C,D> Create<A,B,C,D>(A inA, B inB, C inC, D inD) { return new Tuple<A,B,C,D>(inA, inB, inC, inD); }
        public static void Extract(ref A outA,ref B outB,ref C outC,ref D outD, Tuple<A,B,C,D> t) { outA = first(t); outB = second(t); outC = third(t); outD = fourth(t); }
    }
    public class Tuple<A,B,C,D,E> {
        private A a;
        private B b;
        private C c;
        private D d;
        private E e;
        private Tuple() { }
        private Tuple(A inA, B inB, C inC, D inD, E inE) { this.a = inA; this.b = inB; this.c = inC; this.d = inD; this.e = inE; }

        public static A first(Tuple<A,B,C,D,E> t) { return t.a; }
        public static B second(Tuple<A,B,C,D,E> t) { return t.b; }
        public static C third(Tuple<A,B,C,D,E> t) { return t.c; }
        public static D fourth(Tuple<A,B,C,D,E> t) { return t.d; }
        public static E fifth(Tuple<A,B,C,D,E> t) { return t.e; }

        public static Tuple<A,B,C,D,E> Create<A,B,C,D,E>(A inA, B inB, C inC, D inD, E inE) { return new Tuple<A,B,C,D,E>(inA, inB, inC, inD, inE); }
        public static void Extract(ref A outA,ref B outB,ref C outC,ref D outD,ref E outE, Tuple<A,B,C,D,E> t) { outA = first(t); outB = second(t); outC = third(t); outD = fourth(t); outE = fifth(t); }
    }
    public class Tuple<A,B,C,D,E,F> {
        private A a;
        private B b;
        private C c;
        private D d;
        private E e;
        private F f;
        private Tuple() { }
        private Tuple(A inA, B inB, C inC, D inD, E inE, F inF) { this.a = inA; this.b = inB; this.c = inC; this.d = inD; this.e = inE; this.f = inF; }

        public static A first(Tuple<A,B,C,D,E,F> t) { return t.a; }
        public static B second(Tuple<A,B,C,D,E,F> t) { return t.b; }
        public static C third(Tuple<A,B,C,D,E,F> t) { return t.c; }
        public static D fourth(Tuple<A,B,C,D,E,F> t) { return t.d; }
        public static E fifth(Tuple<A,B,C,D,E,F> t) { return t.e; }
        public static F sixth(Tuple<A,B,C,D,E,F> t) { return t.f; }

        public static Tuple<A,B,C,D,E,F> Create<A,B,C,D,E,F>(A inA, B inB, C inC, D inD, E inE, F inF) { return new Tuple<A,B,C,D,E,F>(inA, inB, inC, inD, inE, inF); }
        public static void Extract(ref A outA,ref B outB,ref C outC,ref D outD,ref E outE,ref F outF, Tuple<A,B,C,D,E,F> t) { outA = first(t); outB = second(t); outC = third(t); outD = fourth(t); outE = fifth(t); outF = sixth(t);}
    }
}
