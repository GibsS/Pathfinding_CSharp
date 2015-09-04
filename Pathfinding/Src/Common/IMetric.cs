using System.Collections;

public interface IMetric<X> {

	float getDistance(X x1, X x2);
}