module SecondHomework.BinaryTree

type TreeNode<'a> =
    | Node of 'a * TreeNode<'a> * TreeNode<'a>
    | Leaf


let rec mapTree mapFunc tree =
    match tree with
    | Leaf -> Leaf
    | Node(value, left, right) -> Node(mapFunc value, mapTree mapFunc left, mapTree mapFunc right)
