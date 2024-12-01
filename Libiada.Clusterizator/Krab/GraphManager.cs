namespace Libiada.Clusterizator.Krab;

/// <summary>
/// Class representing graph of connected nodes.
/// </summary>
public class GraphManager
{
    /// <summary>
    /// Nodes connections in graph.
    /// </summary>
    public readonly List<Connection> Connections;

    /// <summary>
    /// Nodes of graph.
    /// </summary>
    public readonly List<GraphElement> Elements;

    /// <summary>
    /// Initializes a new instance of the <see cref="GraphManager"/> class.
    /// </summary>
    /// <param name="connections">
    /// The connections.
    /// </param>
    /// <param name="elements">
    /// The elements.
    /// </param>
    public GraphManager(List<Connection> connections, List<GraphElement> elements)
    {
        Connections = connections;
        Elements = elements;
    }

    /// <summary>
    /// Nodes connection method.
    /// </summary>
    /// <param name="firstIndex">
    /// First node index.
    /// </param>
    /// <param name="secondIndex">
    /// Second node index.
    /// </param>
    public void Connect(int firstIndex, int secondIndex)
    {
        // if nodes are already in one group
        if ((Elements[firstIndex].TaxonNumber == Elements[secondIndex].TaxonNumber) && (Elements[firstIndex].TaxonNumber != 0))
        {
            return;
        }

        // if both nodes doesn't belong to any group
        if ((Elements[firstIndex].TaxonNumber == 0) && (Elements[secondIndex].TaxonNumber == 0))
        {
            // creating new group
            Elements[firstIndex].TaxonNumber = GetNextTaxonNumber();
            Elements[secondIndex].TaxonNumber = Elements[firstIndex].TaxonNumber;
            Connections[SearchConnection(firstIndex, secondIndex)].Connected = true;
        }
        else if (Elements[firstIndex].TaxonNumber == 0)
        {
            // if only first element doesn't belong to any group connecting it to the existing group
            Elements[firstIndex].TaxonNumber = Elements[secondIndex].TaxonNumber;
            Connections[SearchConnection(firstIndex, secondIndex)].Connected = true;
        }
        else if (Elements[secondIndex].TaxonNumber == 0)
        {
            // if only second element doesn't belong to any group connecting it to the existing group
            Elements[secondIndex].TaxonNumber = Elements[firstIndex].TaxonNumber;
            Connections[SearchConnection(firstIndex, secondIndex)].Connected = true;
        }
        else if (Elements[firstIndex].TaxonNumber > Elements[secondIndex].TaxonNumber)
        {
            // if group of first element has bigger number then we renumber it
            Renumber(firstIndex, Elements[secondIndex].TaxonNumber);
            Connections[SearchConnection(firstIndex, secondIndex)].Connected = true;
        }
        else if (Elements[secondIndex].TaxonNumber > Elements[firstIndex].TaxonNumber)
        {
            // if group of second element has bigger number then we renumber it
            Renumber(secondIndex, Elements[firstIndex].TaxonNumber);
            Connections[SearchConnection(firstIndex, secondIndex)].Connected = true;
        }
    }

    /// <summary>
    /// Searches connection index for pair of nodes.
    /// </summary>
    /// <param name="firstElement">
    /// First node.
    /// </param>
    /// <param name="secondElement">
    /// Second node.
    /// </param>
    /// <returns>
    /// Index of connection in graph as.
    /// </returns>
    public int SearchConnection(GraphElement firstElement, GraphElement secondElement)
    {
        for (int i = 0; i < Connections.Count; i++)
        {
            bool normalOrder = firstElement.Id.Equals(Elements[Connections[i].FirstElementIndex].Id) &&
                               secondElement.Id.Equals(Elements[Connections[i].SecondElementIndex].Id);

            bool inverseOrder = secondElement.Id.Equals(Elements[Connections[i].FirstElementIndex].Id) &&
                                firstElement.Id.Equals(Elements[Connections[i].SecondElementIndex].Id);
            if (normalOrder || inverseOrder)
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// Calculates number of new group.
    /// </summary>
    /// <returns>
    /// Minimum unoccupied number of group.
    /// </returns>
    public int GetNextTaxonNumber()
    {
        return Elements.Max(i => i.TaxonNumber) + 1;
    }

    /// <summary>
    /// Removes connection between given nodes.
    /// Also renumbers groups emerging as result of disconnection.
    /// </summary>
    /// <param name="firstElement">
    /// First node.
    /// </param>
    /// <param name="secondElement">
    /// Second node.
    /// </param>
    public void Cut(GraphElement firstElement, GraphElement secondElement)
    {
        Connection connection = Connections[SearchConnection(firstElement, secondElement)];
        Cut(connection);
    }

    /// <summary>
    /// Removes given connection between given nodes.
    /// Also renumbers groups emerging as result of disconnection.
    /// </summary>
    /// <param name="connection">
    /// Connected nodes pair.
    /// </param>
    public void Cut(Connection connection)
    {
        if (!connection.Connected)
        {
            return;
        }

        connection.Connected = false;
        Renumber(connection.FirstElementIndex, GetNextTaxonNumber());
    }

    /// <summary>
    /// Method creates copy of graph.
    /// </summary>
    /// <returns>
    /// Copy of graph as <see cref="GraphManager"/>
    /// </returns>
    public GraphManager Clone()
    {
        List<Connection> tempConnections = [];
        List<GraphElement> tempGraphElements = [];
        for (int i = 0; i < Connections.Count; i++)
        {
            tempConnections.Add(Connections[i].Clone());
        }

        for (int j = 0; j < Elements.Count; j++)
        {
            tempGraphElements.Add(Elements[j].Clone());
        }

        return new GraphManager(tempConnections, tempGraphElements);
    }

    /// <summary>
    /// Method is connecting nodes into "shortest unclosed path" (snp).
    /// </summary>
    public void ConnectGraph()
    {
        for (int i = 0; i < Elements.Count - 1; i++)
        {
            double minDistance = double.MaxValue;
            int pointNumber = -1;

            // searching for shortest available connection
            for (int j = 0; j < Connections.Count; j++)
            {
                // checking that noeds are in different subgraphs
                bool taxonNumberCheck = (Elements[Connections[j].FirstElementIndex].TaxonNumber !=
                                         Elements[Connections[j].SecondElementIndex].TaxonNumber)
                                        || (Elements[Connections[j].FirstElementIndex].TaxonNumber == 0);
                if ((Connections[j].Lambda < minDistance) && taxonNumberCheck)
                {
                    minDistance = Connections[j].Lambda;
                    pointNumber = j;
                }
            }

            Connect(Connections[pointNumber].FirstElementIndex, Connections[pointNumber].SecondElementIndex);
        }
    }

    /// <summary>
    /// Recursive method for renumeration of connected graph nodes.
    /// </summary>
    /// <param name="index">
    /// Index of element for renumeration.
    /// </param>
    /// <param name="newNumber">
    /// New group number.
    /// </param>
    private void Renumber(int index, int newNumber)
    {
        // changing group of current node
        Elements[index].TaxonNumber = newNumber;
        for (int i = 0; i < Connections.Count; i++)
        {
            // for all connected nodes
            if (Connections[i].Connected)
            {
                if ((Connections[i].FirstElementIndex == index)
                    && (Elements[Connections[i].SecondElementIndex].TaxonNumber != newNumber))
                {
                    Renumber(Connections[i].SecondElementIndex, newNumber);
                }
                else if ((Connections[i].SecondElementIndex == index) &&
                        (Elements[Connections[i].FirstElementIndex].TaxonNumber != newNumber))
                {
                    Renumber(Connections[i].FirstElementIndex, newNumber);
                }
            }
        }
    }

    /// <summary>
    /// Connection search by nodes indexes.
    /// </summary>
    /// <param name="index1">
    /// First element index.
    /// </param>
    /// <param name="index2">
    /// Second element index.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    private int SearchConnection(int index1, int index2)
    {
        return SearchConnection(Elements[index1], Elements[index2]);
    }
}
