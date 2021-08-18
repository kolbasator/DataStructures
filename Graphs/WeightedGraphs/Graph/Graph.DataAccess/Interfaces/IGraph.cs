using System.Collections.Generic; 

namespace Graph.DataAccess.Interfaces
{
    public interface IGraph<T>
    { 
        /// <summary>
        /// Returns the size of the current graph. 
        /// </summary> 
        int GetSize();

        /// <summary>
        /// Returns list of all unvisited neighbours of this vertex.
        /// </summary> 
        List<IVertex<T>> GetUnvisitedNeighbours(IVertex<T> vertex);

        /// <summary>
        /// Returns all incident edges of this vertex.
        /// </summary> 
        public List<IEdge<T>> IncidentEdges(IVertex<T> vertex);

        /// <summary>
        /// Returns all incident edges of this vertex which lead to unvisited neighbors.
        /// </summary> 
        public List<IEdge<T>> IncidentEdgesToUnvisitedVertices(IVertex<T> vertex);

        /// <summary>
        /// Returns a list of all unvisited vertices in this graph.
        /// </summary> 
        List<IVertex<T>> UnVisitedVertices();

        /// <summary>
        /// Adds a new vertex to the graph and returns a reference to it.
        /// </summary>  
        IVertex<T> AddVertex(T data);

        /// <summary>
        /// Adds an edge with the same weight between two vertices with such data.
        /// </summary> 
        IEdge<T> AddEdge(T firstVertex, T secondVertex, int weight);

        /// <summary>
        /// Adds an edge with the same weight between two vertices.
        /// </summary> 
        IEdge<T> AddEdge(IVertex<T> firstVertex, IVertex<T> secondVertex,int weight);

        /// <summary>
        /// Removes a vertex with the same data.
        /// </summary> 
        void RemoveVertex(T data);

        /// <summary>
        /// Removes a vertex by reference. 
        /// </summary> 
        void RemoveVertex(IVertex<T> vertex); 

        /// <summary>
        /// Removes an edge by reference. 
        /// </summary> 
        void RemoveEdge(IEdge<T> edge);

        /// <summary>
        /// Removes edge between two vertices , if such edge exists.
        /// </summary> 
        void RemoveEdge(IVertex<T> firstVertex, IVertex<T> secondVertex);

        /// <summary>
        /// Clears the graph completely.
        /// </summary> 
        void Reset();

        /// <summary>
        /// Removes all edges.
        /// </summary> 
        void ClearEdges();

        /// <summary>
        /// Checks for the presence of a vertex with the same data in the graph. 
        /// </summary> 
        bool ContainsVertex(T data);

        /// <summary>
        /// Checks for the presence of this edge in the graph.
        /// </summary> 
        bool ContainsEdge(IEdge<T> edge);

        /// <summary>
        /// Checks if vertices are connected with the same data.
        /// </summary> 
        bool AreAdjacent(T firstVertex, T secondVertex);

        /// <summary>
        /// Checks if these vertices are connected.
        /// </summary> 
        bool AreAdjacent(IVertex<T> firstVertex, IVertex<T> secondVertex);

        /// <summary>
        /// Returns a list of all the vertices in the graph.
        /// </summary> 
        List<IVertex<T>> GetVertices();

        /// <summary>
        /// Returns a list of all the edges in the graph.
        /// </summary> 
        List<IEdge<T>> GetEdges();

        /// <summary>
        /// Returns a list of all vertices adjacent to a vertex with such data.
        /// </summary> 
        List<IVertex<T>> GetNeighbours(T data);

        /// <summary>
        /// Returns a list of all vertices adjacent to this vertex.
        /// </summary> 
        List<IVertex<T>> GetNeighbours(IVertex<T> vertex);

    }
}
