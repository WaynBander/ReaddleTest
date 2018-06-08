package main

import (
	"bufio"
	"encoding/json"
	"fmt"
	"log"
	"os"
	"strconv"
	"time"
)

func fibonachi(n int) int {

	if n == 0 {
		return 0
	}
	if n == 1 {
		return 1
	}
	return fibonachi(n-1) + fibonachi(n-2)
}

func getInput(input chan string) {
	for {
		in := bufio.NewReader(os.Stdin)
		result, err := in.ReadString('\n')
		if err != nil {
			log.Fatal(err)
		}

		input <- result
	}
}

type Arc struct {
	Fibonachi_Number string
	Count_Fibonachi  string
}

func main() {
	var s = "string"
	var n = "nimber"
	var info = "info"
	var err, k, t, right int
	k = 0
	t = 1
	err = 0
	right = 0
	input := make(chan string, 1)
	go getInput(input)
	for {
		fmt.Println("input next number Fabinachi")
		select {
		case i := <-input:
			s = strconv.Itoa(fibonachi(k)) + "\r\n"
			if i == s {
				fmt.Println("Сorrect value ")
				k = k + t
				right = right + t
				if right == 10 {
					fmt.Println("ten correct answer")
					os.Exit(0)
				}
			}
			if i != s {
				k = k + t
				err = err + t
				right = 0
				fmt.Println("Incorrect value")
				if err == 3 {
					fmt.Println("three incorrect answer")
					os.Exit(0)
				}
			}
		case <-time.After(10 * time.Second):
			n = strconv.Itoa(k)
			info = strconv.Itoa(fibonachi(k))

			arc := Arc{info, n}
			data, err := json.Marshal(arc)
			if err != nil {
				log.Fatal(err)
			}
			fmt.Printf("%s\n", data)

			right = 0
			k = k + t

		}
	}
}
