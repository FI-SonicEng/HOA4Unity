using System;

namespace hoa
{
	public class Binaural
	{
		ulong m_vector_size;
		ulong m_crop_size;
		ulong order;
		ulong numberOfPlanewaves;
		ulong vectorsize;
		T* m_input;
		T* m_result;
		T* m_left;
		T* m_right;

		enum Mode
		{
			RegularMode = 0,
			BinauralMode = 2}
		;

		public Binaural(ulong inputorder, ulong inputnumberOfPlanewaves){
			order = inputorder;
			numberOfPlanewaves = inputnumberOfPlanewaves;
		}


		public Binaural(const ulong order) : Decoder<Hoa3d, T>(order, 2),
		m_vector_size(0ul),
		m_input(nullptr),
		m_result(nullptr),
		m_left(nullptr),
		m_right(nullptr)
		{
			Decoder<Hoa3d, T>::setPlanewaveAzimuth(0, (T)(HOA_PI2*3.));
			Decoder<Hoa3d, T>::setPlanewaveAzimuth(1, (T)HOA_PI2);
			setCropSize(0ul);
		}
			

		virtual void process(T* inputs, T* outputs){
			
		}

		virtual void computeRendering(){
			vectorsize = 64;
		}

			public void setCropSize(const ulong size) 
			{
				if(!size || size > Hrir<Hoa3d, T>::getNumberOfRows())
				{
					m_crop_size = Hrir<Hoa3d, T>::getNumberOfRows();
				}
				else
				{
					m_crop_size = size;
				}
			}


		public  ulong getCropSize()
			{
				if(m_crop_size == Hrir<Hoa3d, T>::getNumberOfRows())
				{
					return 0;
				}
				else
				{
					return m_crop_size;
				}
			}
			
			void computeRendering(const ulong vectorsize = 64) override
			{
				clear();
				m_vector_size  = vectorsize;
				m_input  = Signal<T>::alloc(Hrir<Hoa3d, T>::getNumberOfColumns() * m_vector_size);
				m_result = Signal<T>::alloc(Hrir<Hoa3d, T>::getNumberOfRows() * m_vector_size);
				m_left   = Signal<T>::alloc(Hrir<Hoa3d, T>::getNumberOfRows() + m_vector_size);
				m_right  = Signal<T>::alloc(Hrir<Hoa3d, T>::getNumberOfRows() + m_vector_size);
			}

			private:
			inline void processChannel(const T* harmonics, const T* response, T* vector, T* output) noexcept
			{
				const ulong l = Hrir<Hoa3d, T>::getNumberOfColumns();   // Harmonics size aka 11
				const ulong m = m_crop_size;      // Impulses size
				const ulong n = m_vector_size;    // Vector size
				Signal<T>::mul(m, n, l, response, harmonics, m_result);
				for(ulong i = 0; i < n; i ++)
				{
					Signal<T>::add(m, m_result + i, n, vector + i, 1ul);
				}

				Signal<T>::copy(m_vector_size, vector, output);
				Signal<T>::copy(m, vector + m_vector_size, vector);
				Signal<T>::clear(m_vector_size, vector + m);
			}
			public:

			//! This method performs the binaural decoding and the convolution.
			inline void processBlock(const T** inputs, T** outputs) noexcept
			{
				T* input = m_input;
				for(ulong i = 0; i < Hrir<Hoa3d, T>::getNumberOfColumns() && i < Decoder<Hoa3d, T>::getNumberOfHarmonics(); i++)
				{
					Signal<T>::copy(m_vector_size, inputs[i], input);
					input += m_vector_size;
				}
				processChannel(m_input, Hrir<Hoa3d, T>::getLeftMatrix(), m_left, outputs[0]);
				processChannel(m_input, Hrir<Hoa3d, T>::getRightMatrix(), m_right, outputs[1]);
			}

			inline void process(const T* inputs, T* outputs) noexcept override {}

		};
	}
}

