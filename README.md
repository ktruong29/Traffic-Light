# Traffic Signal
---
The purpose of this program is to design a traffic light interface, declare an
internal clock and set its speed, attach a listener to a clock, and know how to
pause and re-start a clock

## Specifications
---
* Traffic light is off at the initial start of the program
* When the user clicks "Start", the traffic light begins its normal operations at
default speed "slow"
* When the user clicks "Pause", the traffic light freezes where it is. When "Pause"
button is clicked, the string changed to be "Resume" and vice versa
* When the user clicks "Resume", the traffic light begins its operation from the
point in time when operation was suspended

### Rate of change/Speed
---
|          | Red light   | Green light    | Yellow light   |
|:---------|:-----------:|:--------------:|:--------------:|
| Fast     | 4.0s        | 3.0s           | 1.0s           |
| Slow     | 8.0s        | 6.0s           | 2.0s           |

## Prerequisites
---
* A virtual machine
* Install mcs

## Instruction on how to run the program
---
1. chmod +x build.sh then ./build.sh
2. sh build.sh

Copyright [2019] [Kien Truong]
