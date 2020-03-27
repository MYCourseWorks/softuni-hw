#include <stdio.h>
#include <stdbool.h>
#include <math.h>

typedef struct Circle {
	double x; // center x
	double y; // center y
	double r;
} Circle;

typedef struct Rect {
	double x; // top left x
	double y; // top left y
	double w;
	double h;
} Rect;

typedef struct Vector_2D {
	double x;
	double y;
} Vector_2D;

bool is_point_in_circle(Vector_2D* v, Circle* c) {
	double dist = pow(v->x - c->x, 2) + pow(v->y - c->y, 2);
	return dist <= c->r * c->r;
}

bool is_pont_in_rect(Vector_2D* v, Rect* r) {
	bool is_x_in = v->x >= r->x && v->x <= r->x + r->w;
	bool is_y_in = v->y <= r->y && v->y >= r->y - r->h;
	return is_x_in && is_y_in;
}

int main() {
	Circle c = {1, 1, 1.5};
	Rect r = {-1, 1, 6, 2};
	Vector_2D v;

	printf("x = ");
	scanf("%lf", &v.x);
	printf("y = ");
	scanf("%lf", &v.y);

	bool in_circle = is_point_in_circle(&v, &c);
	bool in_rect = is_pont_in_rect(&v, &r);
	printf("%s\n", in_circle && !in_rect ? "yes" : "no");
	return 0;
}
