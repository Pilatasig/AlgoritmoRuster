using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmoRuster.Controlador.ControladorCortePoligono
{
    internal class ControladorWeilerAtherton
    {
        private const float XMIN = -4f, XMAX = 4f, YMIN = -3f, YMAX = 3f;
        private const float EPS = 1e-9f;

        public List<PointF> Resultado { get; private set; }

        private class Nodo
        {
            public PointF Punto;
            public bool EsInterseccion;
            public int EdgeOrigen;
            public float TOrigen;
            public bool EsEntrada;
            public int Siguiente;
            public int Pareja;
            public bool Usado;
        }

        public List<PointF> Recortar(List<PointF> sujeto)
        {
            Resultado = null;
            if (sujeto == null || sujeto.Count < 3) return null;

            List<PointF> sujetoCCW = AsegurarCCW(sujeto);

            List<PointF> clip = new List<PointF>
            {
                new PointF(XMIN, YMIN),
                new PointF(XMAX, YMIN),
                new PointF(XMAX, YMAX),
                new PointF(XMIN, YMAX)
            };

            var ints = EncontrarIntersecciones(sujetoCCW, clip);
            if (ints.Count == 0)
            {
                if (EstaDentroRect(sujetoCCW[0]))
                {
                    Resultado = new List<PointF>(sujetoCCW);
                    return Resultado;
                }
                return null;
            }

            var subjNodos = ConstruirLista(sujetoCCW, ints, true);
            var clipNodos = ConstruirLista(clip, ints, false);

            ClasificarYEnlazar(subjNodos, clipNodos, ints, sujetoCCW);

            var resultado = new List<PointF>();

            for (int pass = 0; pass < subjNodos.Count; pass++)
            {
                int start = -1;
                for (int i = 0; i < subjNodos.Count; i++)
                {
                    if (subjNodos[i].EsInterseccion && !subjNodos[i].EsEntrada && !subjNodos[i].Usado)
                    {
                        start = i;
                        break;
                    }
                }
                if (start == -1) break;

                bool enSujeto = true;
                int current = start;
                int maxIter = (subjNodos.Count + clipNodos.Count) * 10;
                int iterCount = 0;
                do
                {
                    if (iterCount++ > maxIter) break;
                    if (enSujeto)
                    {
                        var n = subjNodos[current];
                        if (current == start && n.Usado) break;
                        resultado.Add(n.Punto);
                        n.Usado = true;
                        if (n.EsInterseccion && !n.EsEntrada)
                        {
                            if (n.Pareja >= 0 && n.Pareja < clipNodos.Count)
                            {
                                current = n.Pareja;
                                enSujeto = false;
                            }
                            else { break; }
                        }
                        else
                        {
                            current = n.Siguiente;
                        }
                    }
                    else
                    {
                        var n = clipNodos[current];
                        resultado.Add(n.Punto);
                        n.Usado = true;
                        if (n.EsInterseccion && n.EsEntrada)
                        {
                            if (n.Pareja >= 0 && n.Pareja < subjNodos.Count)
                            {
                                current = n.Pareja;
                                enSujeto = true;
                            }
                            else { break; }
                        }
                        else
                        {
                            current = n.Siguiente;
                        }
                    }
                } while (!(enSujeto && current == start));
            }

            Resultado = resultado.Count >= 3 ? EliminarDuplicadosConsecutivos(resultado) : null;
            return Resultado;
        }

        private List<(int SubjEdge, float SubjT, int ClipEdge, float ClipT, PointF Pt)>
            EncontrarIntersecciones(List<PointF> sujeto, List<PointF> clip)
        {
            var ints = new List<(int, float, int, float, PointF)>();
            int nS = sujeto.Count;
            for (int i = 0; i < nS; i++)
            {
                PointF A = sujeto[i];
                PointF B = sujeto[(i + 1) % nS];
                for (int j = 0; j < 4; j++)
                {
                    PointF C = clip[j];
                    PointF D = clip[(j + 1) % 4];
                    float dx1 = B.X - A.X, dy1 = B.Y - A.Y;
                    float dx2 = D.X - C.X, dy2 = D.Y - C.Y;
                    float denom = dx1 * dy2 - dy1 * dx2;
                    if (Math.Abs(denom) < 1e-10f) continue;
                    float t1 = ((C.X - A.X) * dy2 - (C.Y - A.Y) * dx2) / denom;
                    float t2 = ((C.X - A.X) * dy1 - (C.Y - A.Y) * dx1) / denom;
                    if (t1 > EPS && t1 < 1 - EPS && t2 > -EPS && t2 < 1 + EPS)
                    {
                        PointF pt = new PointF(A.X + t1 * dx1, A.Y + t1 * dy1);
                        ints.Add((i, t1, j, t2, pt));
                    }
                }
            }
            return ints;
        }

        private List<Nodo> ConstruirLista(List<PointF> poly,
            List<(int SubjEdge, float SubjT, int ClipEdge, float ClipT, PointF Pt)> ints, bool esSujeto)
        {
            var nodos = new List<Nodo>();
            var porArista = new Dictionary<int, List<(float T, PointF Pt)>>();
            for (int k = 0; k < ints.Count; k++)
            {
                var i = ints[k];
                int edgeIdx = esSujeto ? i.SubjEdge : i.ClipEdge;
                float t = esSujeto ? i.SubjT : i.ClipT;
                if (!porArista.ContainsKey(edgeIdx))
                    porArista[edgeIdx] = new List<(float, PointF)>();
                porArista[edgeIdx].Add((t, i.Pt));
            }
            foreach (var kv in porArista)
                kv.Value.Sort((a, b) => a.T.CompareTo(b.T));

            for (int i = 0; i < poly.Count; i++)
            {
                nodos.Add(new Nodo { Punto = poly[i], EsInterseccion = false });
                if (porArista.TryGetValue(i, out var list))
                {
                    foreach (var (t, pt) in list)
                        nodos.Add(new Nodo { Punto = pt, EsInterseccion = true, EdgeOrigen = i, TOrigen = t });
                }
            }
            for (int i = 0; i < nodos.Count; i++)
                nodos[i].Siguiente = (i + 1) % nodos.Count;
            return nodos;
        }

        private void ClasificarYEnlazar(List<Nodo> subj, List<Nodo> clip,
            List<(int SubjEdge, float SubjT, int ClipEdge, float ClipT, PointF Pt)> ints,
            List<PointF> sujetoCCW)
        {
            var subjMap = new Dictionary<(int, float), Queue<int>>();
            for (int i = 0; i < subj.Count; i++)
                if (subj[i].EsInterseccion)
                {
                    var key = (subj[i].EdgeOrigen, subj[i].TOrigen);
                    if (!subjMap.ContainsKey(key))
                        subjMap[key] = new Queue<int>();
                    subjMap[key].Enqueue(i);
                }

            var clipMap = new Dictionary<(int, float), Queue<int>>();
            for (int i = 0; i < clip.Count; i++)
                if (clip[i].EsInterseccion)
                {
                    var key = (clip[i].EdgeOrigen, clip[i].TOrigen);
                    if (!clipMap.ContainsKey(key))
                        clipMap[key] = new Queue<int>();
                    clipMap[key].Enqueue(i);
                }

            foreach (var i in ints)
            {
                int sKey = i.SubjEdge;
                float sT = i.SubjT;
                int cKey = i.ClipEdge;
                float cT = i.ClipT;
                if (!subjMap.TryGetValue((sKey, sT), out var sQ) || sQ.Count == 0) continue;
                if (!clipMap.TryGetValue((cKey, cT), out var cQ) || cQ.Count == 0) continue;
                int sIdx = sQ.Dequeue();
                int cIdx = cQ.Dequeue();

                subj[sIdx].Pareja = cIdx;
                clip[cIdx].Pareja = sIdx;

                float beforeT = Math.Max(0, i.SubjT - 0.001f);
                PointF beforeP = new PointF(
                    sujetoCCW[i.SubjEdge].X +
                        (sujetoCCW[(i.SubjEdge + 1) % sujetoCCW.Count].X - sujetoCCW[i.SubjEdge].X) * beforeT,
                    sujetoCCW[i.SubjEdge].Y +
                        (sujetoCCW[(i.SubjEdge + 1) % sujetoCCW.Count].Y - sujetoCCW[i.SubjEdge].Y) * beforeT);
                bool antesAdentro = EstaDentroRect(beforeP);
                subj[sIdx].EsEntrada = !antesAdentro;
                clip[cIdx].EsEntrada = !antesAdentro;
            }
        }

        private bool EstaDentroRect(PointF p)
        {
            return p.X >= XMIN - EPS && p.X <= XMAX + EPS &&
                   p.Y >= YMIN - EPS && p.Y <= YMAX + EPS;
        }

        private List<PointF> EliminarDuplicadosConsecutivos(List<PointF> pts)
        {
            if (pts.Count < 2) return pts;
            var r = new List<PointF> { pts[0] };
            for (int i = 1; i < pts.Count; i++)
            {
                float dx = pts[i].X - pts[i - 1].X;
                float dy = pts[i].Y - pts[i - 1].Y;
                if (dx * dx + dy * dy > 1e-9f)
                    r.Add(pts[i]);
            }
            return r;
        }

        private List<PointF> AsegurarCCW(List<PointF> poly)
        {
            float area = 0;
            for (int i = 0; i < poly.Count; i++)
            {
                int j = (i + 1) % poly.Count;
                area += poly[i].X * poly[j].Y - poly[j].X * poly[i].Y;
            }
            if (area >= 0) return new List<PointF>(poly);
            var rev = new List<PointF>(poly);
            rev.Reverse();
            return rev;
        }
    }
}
