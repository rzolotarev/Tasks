

if we don't include then the max value is the same as for i - 1 items;
If we include "i" item we have to get max for (capacity - i-weight) and add them up.
1. Max value we can obtain from 1,2,3...i is the same max value we can obtain from 1,2,3,i-1 without taking i item;
2. to find the max value of n items, we have to find out max value for (n - 1) items and deciding is it better to take a n item.
max value for (n - 1) item is max value for (n-2)


Key point of reasoning.
1. We can take only two operations either include an item or not;
2. Question. Do we have larger value with the particular item or without for particular max weight?
3. That's why we take Max for (with, without).
a) If without it means Max for (i - 1) items;
b) If with it means Vi + Max value for (i - 1) items for max weight = total capacity - Wi;

Does order make sense?
No. We depende on values for calculation for previous items. This value is constrcuted regardless of the order.
For instance, if the last item will be the smallest one, we calculate is it better to take the item or not.
If not, the max is max for ( i - 1 ) items. If we include and is able to include, Vi + Max value for ( i - 1) and capacity = total capacity - Wi;
