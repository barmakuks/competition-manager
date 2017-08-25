using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TA.Corel;
using TA.Competitions.Forms;

namespace TA.CompetitionControllers
{
    /// <summary>
    /// ��������� ��� ���������� ����� ������ ������������
    /// </summary>
    public interface CompetitionController
    {
        Competition Competition
        {
            get;
            set;
        }
        /// <summary>
        /// ������������ ����� ������
        /// </summary>
        /// <param name="aCompetitionId"></param>
        bool SeedPlayers();
        /// <summary>
        /// �������� Control, �������������� ����� ������� ���� ������������
        /// </summary>
        /// <returns></returns>
        CompetitionPanel GetControl();
        /// <summary>
        /// ���������� UserControl ��� �������������� ������������� ���������� ������������
        /// </summary>
        /// <returns>CompetitionParamsPanel</returns>
        CompetitionParamsPanel GetParametersPanel();
        /// <summary>
        /// ���������� ������ � �������� ������.
        /// ���� ������� ���������� ��� : i-� ���� {M[i*2] ������ M[i*2 + 1]}
        /// </summary>
        /// <param name="playerCount">���������� ������� ��� ������</param>
        /// <returns></returns>
        int[] GetDrawOrder(int playerCount);
    }
}
