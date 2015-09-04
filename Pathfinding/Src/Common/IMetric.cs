using System.Collections;

public interface IMetric<Y, X> {

	float getDistance(X x1, X x2);
	float getDistance(Y point, X x);
}