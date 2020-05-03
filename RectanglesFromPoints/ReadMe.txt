
								x3y2
		        x1y1    x2y1	x3y1
                x1y0    x2y0	x3y0

If we group by x coordinates we will get all points belonging to the one x.
				x1: [y0, y1]
				x2: [y0, y1]
				x3: [y0, y1, y2]
What do we see? We can form a rectangular if points have the same "y" coordinates, the same pair of 
"y" coordinates on different "x" coordinates.

For such combination we can form one rectangular;
y1  y1
y0  y0

For such combination we can form 3 rectangulars;
y1  y1 y1
y0  y0 y0           

It's a formula from combinatoric - all combinations of k(2) from n (3). 

C(2,2) = C(1,1) + C(1,2) = 1 + 0 = 1;

C(3,2) = C(2,2) + C(2, 1) = 1 + 2 = 3; C(2,1) = count of verticle lines - 1
C(2,2) - is stored in number variables;

y1  y1 y1 y1
y0  y0 y0 y0          

C(4,2) = C(3,2) + C(3,1) = 3 + 3; C(3,1) = count of verticle lines - 1
