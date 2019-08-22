module Barteklu.Kata.Square

open System

let make letter =
  let letters = ['A'..letter]

  let reversedLettersTail =
    letters
    |> List.rev
    |> List.tail

  letters @ reversedLettersTail
  |> Array.ofList
  |> String.Concat

  
