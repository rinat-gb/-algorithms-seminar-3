using System.Text;

namespace listrevert;

// непосредственно список
//
// я не стал создавать методы для поиска значения и для удаления элемента, это тривиально
// только методы добавления элемента и разворота списка
class List<T>
{
    // вспомогательный класс для хранения элемента списка
    private class Node<U>
    {
        public U value { get; set; }
        public Node<U> next { get; set; }
    }

    // голова списка
    private Node<T> head;

    // метод вставки элемента
    public void add(T value)
    {
        // создаём новую ноду с требуемым значением
        Node<T> n = new Node<T>();

        // запоминаем значение, поле n.next уже инициализировано в null предыдущим конструктором
        n.value = value;

        // это самый первый элемент?
        if (head == null)
        {
            // да
            head = n;
        }
        // иначе вставляем ноду после хвоста
        else
        {
            // ищем самый последний элемент в цикле, сложность получается O(n)
            Node<T> currNode = head;

            while (currNode.next != null)
            {
                currNode = currNode.next;
            }
            // и вставляем наш элемент после последнего
            currNode.next = n;
        }
    }

    // метод разворота списка
    public void revert()
    {
        // если в списке меньше двух элементов то разворачивать его не имеет смысла
        if (head != null && head.next != null)
        {
            // запоминаем будущий хвост списка, который сейчас является головой
            Node<T> tailNode = head;

            // вызываем вспомогательный рекурсивный метод поэлементного разворота
            doRevert(head.next, head);

            // и говорим что в хвостовом (последнем) элементе никакого следующего элемента нет
            tailNode.next = null;
        }
    }

    // вспомогательный рекурсивный метод поэлементного разворота
    private void doRevert(Node<T> currNode, Node<T> prevNode)
    {
        // если это последний элемент, то делаем его головой списка
        if (currNode.next == null)
            head = currNode;
        else
        {
            // иначе рекурсивно вызываем сам себя для следующего элемента
            doRevert(currNode.next, currNode);
        }
        // говорим что следующий элемент теперь будет предыдущим элементом
        currNode.next = prevNode;
    }

    // просто override для удобства вывода списка через Console.Write
    public override string ToString()
    {
        // начинаем вывод с открывающей квадратной скобки
        StringBuilder sb = new StringBuilder("[");

        // если список пустой то просто пишем "-- пусто --"
        if (head == null)
        {
            sb.Append("-- пусто --");
        }
        else
        {
            Node<T> currNode = head;

            // просматриваем все элементы списка
            do
            {
                sb.Append(currNode.value);

                // указатель на следующий элемент
                currNode = currNode.next;

                // если это не последний элемент то отделяем от последующего запятой с пробелом
                if (currNode != null)
                    sb.Append(", ");

            } while (currNode != null);
        }

        // для красивости "закрываем" вывод квадратной скобкой
        sb.Append(']');
        return sb.ToString();
    }
}
