#include <stdio.h>
#include <stdbool.h>
#include <math.h>

typedef struct Circle {
	double x;
	double y;
	double r;
} Circle;

typedef struct Vector_2D {
	double x;
	double y;
} Vector_2D;

bool is_point_in_circle(Vector_2D* v, Circle* c) {
	double dist = pow(v->x - c->x, 2) + pow(v->y - c->y, 2);
	return dist <= c->r * c->r;
}

int main() {
	Circle c = {0, 0, 2};
	Vector_2D v = {0, 0};
	printf("x = ");
	scanf("%lf", &v.x);
	printf("y = ");
	scanf("%lf", &v.y);
	char* answer = is_point_in_circle(&v, &c) == true ? "Yes" : "No";
	printf("%s\n", answer);
	return 0;
}