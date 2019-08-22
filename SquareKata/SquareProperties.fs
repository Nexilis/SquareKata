module Barteklu.Kata.SquareProperties

open System
open FsCheck
open FsCheck.Xunit

let letterPosition (letter: char) : int =
    int letter - int 'A'

type Letters =
  static member Char() =
    Arb.Default.Char()
    |> Arb.filter (fun c -> 'A' <= c && c <= 'Z')

type SquarePropertyAttribute () =
  inherit PropertyAttribute(Arbitrary = [| typeof<Letters> |])

[<SquareProperty>]
let ``Square is not-empty`` (letter: char) =

  let actual = Square.make letter

  not (String.IsNullOrWhiteSpace actual)

[<SquareProperty>]
let ``Square horizontal edge length depends on letter position in alphabet`` (letter: char) =
  let actual = Square.make letter

  let expectedLength = 2 * letterPosition letter + 1

  actual.Length = expectedLength

[<SquareProperty>]
let ``Square horizontal edge is a palindrome`` (letter: char) =
  let actual = Square.make letter
  let expected =
    actual.ToCharArray()
    |> Array.rev
    |> String.Concat

  actual = expected

[<SquareProperty>]
let ``Square horizontal and vertical edges have the same length`` (letter: char) =
  let actual = Square.make letter
  let split = actual.Split('\n')
  split.[0].Length = split.Length
