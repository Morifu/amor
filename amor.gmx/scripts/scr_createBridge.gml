var start_x = x + lengthdir_x((sprite_width /2),image_angle + 180);
var start_y = y + lengthdir_y((sprite_height /2),image_angle + 180);

var end_x = x + lengthdir_x((sprite_width /2),image_angle);
var end_y = y + lengthdir_y((sprite_height /2),image_angle);

var bridgeSlope = point_direction(start_x,start_y,end_x,end_y);
